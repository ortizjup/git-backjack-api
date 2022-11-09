using BlackJack.NetCore.Web.Api.Dtos.Reportes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Servicios
{
    public interface IReporteService
    {
        Task<ReporteIndicePartidaGanadasCrupier> GetReporteIndicePartidaGanadasCrupier(int idJugador);
        Task<List<ReporteCantidadJuegosYJugadoresPorDia>> GetReporteCantidadJuegosYJugadoresPorDia();
        Task<ReportePromedioPartidasBlackJack> GetReportePromedioPartidasBlackJack(int idUsuario);
    }
}