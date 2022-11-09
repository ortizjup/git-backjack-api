using BlackJack.NetCore.Web.Api.DataContext;
using BlackJack.NetCore.Web.Api.Dtos.Reportes;
using BlackJack.NetCore.Web.Api.Services.Security;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public class ReporteService : IReporteService
    {
        private readonly TpiBlackJackDbContext _tpiBlackJackDbContext;
        private readonly ISecurityService _securityService;

        public ReporteService(TpiBlackJackDbContext tpiBlackJackDbContext, ISecurityService securityService)
        {
            _tpiBlackJackDbContext = tpiBlackJackDbContext;
            _securityService = securityService;
        }

        public async Task<ReporteIndicePartidaGanadasCrupier> GetReporteIndicePartidaGanadasCrupier(int idJugador)
        {
            var partidas = await _tpiBlackJackDbContext.Juegos
                .AsNoTracking()
                .Include(x => x.IdUsuarioNavigation)
                .Include(x => x.DetallesJuego)
                .ThenInclude(x => x.IdCartaNavigation)
                .ThenInclude(x => x.IdCategoriaNavigation)
                .Where(x => x.IdUsuario == idJugador)
                .ToListAsync();

            var totalPartidas = partidas.Count();
            var partidasGanadasCrupier = 0;
            var partidasGanadasJugador = 0;

            if (totalPartidas <= 0)
            {
                return new ReporteIndicePartidaGanadasCrupier
                {
                    PorcentajeCrupier = 0,
                    PorcentajeJugador = 0
                };
            }

            foreach (var partida in partidas.GroupBy(x => x.IdJuego))
            {
                partidasGanadasCrupier += partida.Where(x => x.DetallesJuego.Where(x => x.EsCartaCrupier).Sum(x => x.ValorCarta) > x.DetallesJuego.Where(x => !x.EsCartaCrupier).Sum(x => x.ValorCarta)).Count();
                partidasGanadasJugador += partida.Where(x => x.DetallesJuego.Where(x => x.EsCartaCrupier).Sum(x => x.ValorCarta) < x.DetallesJuego.Where(x => !x.EsCartaCrupier).Sum(x => x.ValorCarta)).Count();
            }

            return new ReporteIndicePartidaGanadasCrupier { PorcentajeCrupier = ((partidasGanadasCrupier / totalPartidas) * 100), PorcentajeJugador = ((partidasGanadasJugador / totalPartidas) * 100) };
        }

        public async Task<List<ReporteCantidadJuegosYJugadoresPorDia>> GetReporteCantidadJuegosYJugadoresPorDia()
        {
            var results = new List<ReporteCantidadJuegosYJugadoresPorDia>();

            var query = await _tpiBlackJackDbContext.Juegos
              .AsNoTracking()
              .Include(x => x.IdUsuarioNavigation)
              .Include(x => x.DetallesJuego)
              .ThenInclude(x => x.IdCartaNavigation)
              .ThenInclude(x => x.IdCategoriaNavigation)
              .ToListAsync();

            if (query.Count() <= 0)
            {
                return new List<ReporteCantidadJuegosYJugadoresPorDia>();
            }

            foreach (var group in query.GroupBy(x => x.Fecha.Date))
            {
                results.Add(new ReporteCantidadJuegosYJugadoresPorDia
                {
                    GameDate = group.Key.ToString("dd/MM/yyy"),
                    CantidadJuegos = group.ToList().Select(s => s.IdJuego).Count(),
                    CantidadJugadores = group.ToList().Select(s => s.IdUsuario).Count()
                });
            }

            return await Task.FromResult(results);
        }

        public async Task<ReportePromedioPartidasBlackJack> GetReportePromedioPartidasBlackJack(int idUsuario)
        {
            var query = await _tpiBlackJackDbContext.Juegos
              .AsNoTracking()
              .Include(x => x.IdUsuarioNavigation)
              .Include(x => x.DetallesJuego)
              .ThenInclude(x => x.IdCartaNavigation)
              .ThenInclude(x => x.IdCategoriaNavigation)
              .Where(x => x.IdUsuario == idUsuario)
              .ToListAsync();

            var group = query.GroupBy(x => x.IdJuego);

            if (group.Count() <= 0)
            {
                return new ReportePromedioPartidasBlackJack
                {
                    PromedioBlackJackJugador = 0,
                    PromedioBlackJackCrupier = 0
                };
            }

            var juegosJugadorBl = 0;
            var juegosCrupierBl = 0;

            foreach (var item in group)
            {
                juegosJugadorBl += item.Count(x => x.DetallesJuego.Where(x => !x.EsCartaCrupier).Sum(x => x.ValorCarta) == 21);
                juegosCrupierBl += item.Count(x => x.DetallesJuego.Where(x => x.EsCartaCrupier).Sum(x => x.ValorCarta) == 21);
            }

            return new ReportePromedioPartidasBlackJack
            {
                PromedioBlackJackJugador = ((juegosJugadorBl / group.Count()) * 100),
                PromedioBlackJackCrupier = ((juegosCrupierBl / group.Count()) * 100)
            };
        }
    }
}
