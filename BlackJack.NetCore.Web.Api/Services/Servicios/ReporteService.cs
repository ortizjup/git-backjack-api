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
           .Where(x => x.IdUsuario == idJugador && !x.Activo)
           .ToListAsync();

            decimal totalPartidas = partidas.GroupBy(x => x.IdJuego).Count();
            decimal partidasGanadasCrupier = partidas.Where(x => x.GanoJugador == false && !(x.EsEmpate ?? false)).Count();
            decimal partidasGanadasJugador = partidas.Where(x => x.GanoJugador == true && !(x.EsEmpate ?? false)).Count();

            if (totalPartidas <= 0)
            {
                return new ReporteIndicePartidaGanadasCrupier
                {
                    PorcentajeCrupier = 0,
                    PorcentajeJugador = 0
                };
            }

            return new ReporteIndicePartidaGanadasCrupier
            {
                PorcentajeCrupier = ((partidasGanadasCrupier / totalPartidas) * 100),
                PorcentajeJugador = ((partidasGanadasJugador / totalPartidas) * 100)
            };
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
                    GameDate = group.Key.ToString("MM/dd/yyyy"),
                    CantidadJuegos = group.Count(),
                    CantidadJugadores = group.Select(s => s.IdUsuario).Count()
                });
            }

            return await Task.FromResult(results);
        }

        public async Task<ReportePromedioPartidasBlackJack> GetReportePromedioPartidasBlackJack(int idUsuario)
        {
            decimal juegosJugadorBl = 0;
            decimal juegosCrupierBl = 0;
            var query = await _tpiBlackJackDbContext.Juegos
              .AsNoTracking()
              .Include(x => x.IdUsuarioNavigation)
              .Include(x => x.DetallesJuego)
              .ThenInclude(x => x.IdCartaNavigation)
              .ThenInclude(x => x.IdCategoriaNavigation)
              .Where(x => x.IdUsuario == idUsuario && !x.Activo && !(x.EsEmpate ?? false))
              .ToListAsync();

            var group = query.GroupBy(x => x.IdJuego);
            var count = group.Count();

            if (group.Count() <= 0)
            {
                return new ReportePromedioPartidasBlackJack
                {
                    PromedioBlackJackJugador = 0,
                    PromedioBlackJackCrupier = 0
                };
            }
            foreach (var item in group)
            {
                juegosJugadorBl += item.Count(x => x.DetallesJuego.Where(x => !x.EsCartaCrupier).Sum(x => x.ValorCarta) == 21);
                juegosCrupierBl += item.Count(x => x.DetallesJuego.Where(x => x.EsCartaCrupier).Sum(x => x.ValorCarta) == 21);
            }

            return new ReportePromedioPartidasBlackJack
            {
                PromedioBlackJackJugador = ((juegosJugadorBl / count) * 100),
                PromedioBlackJackCrupier = ((juegosCrupierBl / count) * 100)
            };
        }
    }
}
