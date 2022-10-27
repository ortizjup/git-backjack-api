using BlackJack.NetCore.Web.Api.DataContext;
using BlackJack.NetCore.Web.Api.Dtos.Juego;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public class CartaService : ICartaService
    {
        private readonly TpiBlackJackDbContext _tpiBlackJackDbContext;

        public CartaService(TpiBlackJackDbContext tpiBlackJackDbContext)
        {
            _tpiBlackJackDbContext = tpiBlackJackDbContext;
        }

        public async Task<List<CartaDto>> SolicitarCartas(int idJuego, int idUsuario, int cantidadCartasSolicitadas, bool esCrupier)
        {
            var retVal = new List<CartaDto>();

            for (int i = 0; i < cantidadCartasSolicitadas; i++)
            {
                var min = 1;
                var max = 52;

                var cartasActuales = _tpiBlackJackDbContext.DetallesJuego.AsNoTracking()
                    .Where(x => x.IdJuego == idJuego && x.IdJuegoNavigation.IdUsuario == idUsuario && x.IdJuegoNavigation.Activo && x.EsCartaCrupier == esCrupier)
                    .Select(x => x.IdCartaNavigation)
                    .ToList();

                var numero = new Random().Next(min, max);
                var cartasDisponibles = Enumerable.Range(min, max).Except(cartasActuales.Select(x => x.Numero).ToList());

                while (!cartasDisponibles.Any(x => x == numero))
                {
                    numero = new Random().Next(min, max);
                }

                retVal.Add(await _tpiBlackJackDbContext.Cartas
                    .Include(x => x.IdCategoriaNavigation)
                    .Include(x => x.CartasValores)
                    .ThenInclude(x => x.IdValorNavigation)
                    .AsNoTracking().FirstOrDefaultAsync(x => x.IdCarta == numero));
            }

            return retVal;
        }

        public async Task<List<CartaDto>> SolicitarCartasFinPartidaCrupier(int idJuego, int idUsuario, int scoreActual, bool esCrupier)
        {
            var retVal = new List<CartaDto>();

            while(scoreActual < 17)
            {
                var min = 1;
                var max = 52;

                var cartasActuales = _tpiBlackJackDbContext.DetallesJuego.AsNoTracking()
                    .Where(x => x.IdJuego == idJuego && x.IdJuegoNavigation.IdUsuario == idUsuario && x.IdJuegoNavigation.Activo && x.EsCartaCrupier == esCrupier)
                    .Select(x => x.IdCartaNavigation)
                    .ToList();

                var numero = new Random().Next(min, max);
                var cartasDisponibles = Enumerable.Range(min, max).Except(cartasActuales.Select(x => x.Numero).ToList());

                while (!cartasDisponibles.Any(x => x == numero))
                {
                    numero = new Random().Next(min, max);
                }

                retVal.Add(await _tpiBlackJackDbContext.Cartas
                    .Include(x => x.IdCategoriaNavigation)
                    .Include(x => x.CartasValores)
                    .ThenInclude(x => x.IdValorNavigation)
                    .AsNoTracking().FirstOrDefaultAsync(x => x.IdCarta == numero));

                scoreActual = scoreActual + retVal.Sum(x => x.Valores.FirstOrDefault());
            }

            return retVal;
        }
    }
}
