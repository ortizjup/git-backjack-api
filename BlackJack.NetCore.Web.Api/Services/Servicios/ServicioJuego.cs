using BlackJack.NetCore.Web.Api.DataContext;
using BlackJack.NetCore.Web.Api.Dtos.Juego;
using BlackJack.NetCore.Web.Api.Dtos.Juego.Request;
using BlackJack.NetCore.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public class ServicioJuego : IServicioJuego
    {
        private readonly TpiBlackJackDbContext _tpiBlackJackDbContext;

        public ServicioJuego(TpiBlackJackDbContext tpiBlackJackDbContext)
        {
            _tpiBlackJackDbContext = tpiBlackJackDbContext;
        }

        public async Task<ActiveGameSetupDto> GetActiveGame(int idUsuario)
        {
            var retVal = new ActiveGameSetupDto();
            var juegoActivo = await _tpiBlackJackDbContext.Juegos
                    .Include(x => x.IdUsuarioNavigation)
                    .Include(x => x.DetallesJuego)
                        .ThenInclude(x => x.IdCartaNavigation)
                            .ThenInclude(x => x.IdCategoriaNavigation)
                    .OrderByDescending(x => x.IdJuego)
                    .FirstOrDefaultAsync(x => x.IdUsuario == idUsuario && x.Activo);

            if (juegoActivo?.Activo ?? false)
            {
                var cartasCrupier = await _tpiBlackJackDbContext.DetallesJuego.AsNoTracking().Where(x => x.IdJuego == juegoActivo.IdJuego && x.EsCartaCrupier).Select(x => new CartaDto
                {
                    Id = x.IdCarta,
                    IdCategoria = x.IdCartaNavigation.IdCategoria,
                    Identificador = x.IdCarta,
                    Nombre = x.IdCartaNavigation.Nombre,
                    Numero = x.IdCartaNavigation.Numero,
                    Valores = new List<int> { x.ValorCarta }.ToArray(),
                    CategoriaCartaDto = x.IdCartaNavigation.IdCategoriaNavigation
                }).ToListAsync();

                var cartasJugador = await _tpiBlackJackDbContext.DetallesJuego.AsNoTracking().Where(x => x.IdJuego == juegoActivo.IdJuego && !x.EsCartaCrupier).Select(x => new CartaDto
                {
                    Id = x.IdCarta,
                    IdCategoria = x.IdCartaNavigation.IdCategoria,
                    Identificador = x.IdCarta,
                    Nombre = x.IdCartaNavigation.Nombre,
                    Numero = x.IdCartaNavigation.Numero,
                    Valores = new List<int> { x.ValorCarta }.ToArray(),
                    CategoriaCartaDto = x.IdCartaNavigation.IdCategoriaNavigation
                }).ToListAsync();

                foreach (var juego in juegoActivo.DetallesJuego)
                {
                    retVal.idUsuario = idUsuario;
                    retVal.idJuego = juego.IdJuego;
                    retVal.Active = true;
                    retVal.CartasUsuario = cartasJugador;
                    retVal.CartasCrupier = cartasCrupier;
                    retVal.Jugador = juegoActivo.IdUsuarioNavigation;
                    retVal.ScoreCrupier = cartasCrupier.Sum(x => x.Valores.FirstOrDefault());
                    retVal.ScoreJugador = cartasJugador.Sum(x => x.Valores.FirstOrDefault());
                    retVal.juegoDto = juegoActivo;

                }
            }
            
            return retVal;
        }

        public async Task<JuegoDto> GetJuegoById(int idJuego, bool esCrupier, bool active)
        {
            return await _tpiBlackJackDbContext.Juegos
                .AsNoTracking()
                .Include(x => x.DetallesJuego)
                .ThenInclude(x => x.IdCartaNavigation)
                .Include(x => x.DetallesJuego)
                .ThenInclude(x => x.IdJuegoNavigation)
                .Include(x => x.IdUsuarioNavigation)
                .FirstOrDefaultAsync(x => x.IdJuego == idJuego && x.Activo == active && x.DetallesJuego.All(x => x.EsCartaCrupier == esCrupier)); ;
        }

        public async Task AddDetalleJuego(Dtos.Juego.DetallesJuegoDto dto)
        {
            await _tpiBlackJackDbContext.DetallesJuego.AddAsync(dto);
            await _tpiBlackJackDbContext.SaveChangesAsync();
        }

        public async Task AddDetallesJuegos(List<CartaDto> cartas, int idJuego, bool esCartaCrupier)
        {
            var lista = new List<DetallesJuego>();

            cartas.ForEach(x =>
            {
                lista.Add(new DetallesJuego { IdJuego = idJuego, EsCartaCrupier = esCartaCrupier, IdCarta = x.Id, ValorCarta = x.Valores.FirstOrDefault() });
            });

            await _tpiBlackJackDbContext.AddRangeAsync(lista);
            await _tpiBlackJackDbContext.SaveChangesAsync();
        }

        public async Task<JuegoDto> AddJuego(int idUsuario)
        {
            var juego = new Juegos { IdUsuario = idUsuario, IdJuego = 0, Activo = true, Description = string.Empty, Fecha = DateTime.Now, GanoJugador = false };
            await _tpiBlackJackDbContext.AddAsync(juego);
            await _tpiBlackJackDbContext.SaveChangesAsync();
            return await _tpiBlackJackDbContext.Juegos.Include(x => x.IdUsuarioNavigation).OrderByDescending(x => x.IdJuego).FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);
        }

        public async Task UpdateValorCarta(int idUsuario, int idJuego, int idCarta, int valorSolicitado)
        {
            var detalles = await _tpiBlackJackDbContext.DetallesJuego
                .Include(x => x.IdJuegoNavigation)
                .Include(x => x.IdCartaNavigation)
                .FirstOrDefaultAsync(x => x.IdJuego == idJuego &&
                x.IdJuegoNavigation.IdUsuario == idUsuario &&
                x.IdJuegoNavigation.Activo &&
                x.IdCartaNavigation.IdCarta == idCarta &&
                !x.EsCartaCrupier);

            detalles.ValorCarta = valorSolicitado;

            await _tpiBlackJackDbContext.SaveChangesAsync();
        }

        public async Task UpdateGameStatus(int idUsuario, int idJuego, int scoreCrupier, int scoreJugador)
        {
            var juego = await _tpiBlackJackDbContext.Juegos.FirstOrDefaultAsync(x => x.IdUsuario == idUsuario && x.IdJuego == idJuego);

            juego.ScoreCrupier = scoreCrupier;
            juego.ScoreJugador = scoreJugador;
            juego.Activo = false;
            juego.GanoJugador = scoreCrupier <= scoreJugador;

            await _tpiBlackJackDbContext.SaveChangesAsync();
        }

        public async Task<List<JuegoDto>> GetLatestGames(int idUsuario)
        {
            return await _tpiBlackJackDbContext.Juegos
                .AsNoTracking()
                .Include(x => x.IdUsuarioNavigation)
                .Include(x => x.DetallesJuego)
                    .ThenInclude(x => x.IdCartaNavigation)
                        .ThenInclude(x => x.IdCategoriaNavigation)
                .Where(x => x.IdUsuario == idUsuario)
                .OrderByDescending(d => d.IdJuego)
                .Skip(0).Take(10)
                .Select<Juegos, JuegoDto>(x => x).ToListAsync();
        }
    }
}
