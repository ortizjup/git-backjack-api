using BlackJack.NetCore.Web.Api.Dtos.Juego.Request;
using BlackJack.NetCore.Web.Api.Services.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Controllers.Juego
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class JuegoController : Controller
    {
        private readonly IServicioJuego _servicio;

        public JuegoController(IServicioJuego servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("loadActiveGame/{idUsuario}")]
        public async Task<IActionResult> LoadActiveGame(int idUsuario)
        {
            return Ok(await _servicio.GetActiveGame(idUsuario));
        }

        [HttpPost("getJuegoInfo")]
        public async Task<IActionResult> GetJuegoById([FromBody] RequestGameInfoDto dto)
        {
            return Ok(await _servicio.GetJuegoById(dto.IdJuego, dto.EsCrupier, dto.Active));
        }

        [HttpPost("addJuego/{idUsuario}")]
        public async Task<IActionResult> AddJuego(int idUsuario)
        {
            return Ok(await _servicio.AddJuego(idUsuario));
        }

        [HttpPost("updateValorCarta")]
        public async Task<IActionResult> UpdateValorCarta([FromBody] UpdateCartaValueDto dto)
        {
            await _servicio.UpdateValorCarta(dto.IdUsuario, dto.IdJuego, dto.IdCarta, dto.ValorSolicitado);
            return Ok();
        }

        
        [HttpPost("updateGameStatus")]
        public async Task<IActionResult> UpdateGameStatus([FromBody] UpdateGameStatusRequestDto dto)
        {
            await _servicio.UpdateGameStatus(dto.idUsuario, dto.idJuego, dto.scoreCrupier, dto.scoreCrupier);
            return Ok();
        }

        [HttpGet("getLatestGamesForUser/{idUsuario}")]
        public async Task<IActionResult> UpdateGameStatus(int idUsuario)
        {
            return Ok(await _servicio.GetLatestGames(idUsuario));
        }
    }
}
