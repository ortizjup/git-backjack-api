using BlackJack.NetCore.Web.Api.Services.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Controllers.Reportes
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : Controller
    {
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet("getIndiceDeVictoriaCrupier/{idJugador}")]
        public async Task<IActionResult> GetIndiceDeVictoriaCrupier(int idJugador)
        {
            return Ok(await _reporteService.GetReporteIndicePartidaGanadasCrupier(idJugador));
        }

        [HttpGet("cantidadJuegosYJugadoresPorDia")]
        public async Task<IActionResult> GetCantidadJuegosYJugadoresPorDia()
        {
            return Ok(await _reporteService.GetReporteCantidadJuegosYJugadoresPorDia());
        }


        [HttpGet("getReportePromedioPartidasBlackJack/{idUsuario}")]
        public async Task<IActionResult> GetReportePromedioPartidasBlackJack(int idUsuario)
        {
            return Ok(await _reporteService.GetReportePromedioPartidasBlackJack(idUsuario));
        }
    }
}
