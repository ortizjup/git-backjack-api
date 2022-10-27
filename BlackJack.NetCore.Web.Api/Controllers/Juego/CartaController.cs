using BlackJack.NetCore.Web.Api.Dtos.Juego;
using BlackJack.NetCore.Web.Api.Dtos.Juego.Request;
using BlackJack.NetCore.Web.Api.Services.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Controllers.Juego
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartaController : Controller
    {
        private readonly ICartaService _cartaService;
        private readonly IServicioJuego _servicio;

        public CartaController(ICartaService cartaService,
            IServicioJuego servicioJuego)
        {
            _cartaService = cartaService;
            _servicio = servicioJuego;
        }

        [HttpPost("solicitarCartas")]
        public async Task<IActionResult> SolicitarCartas([FromBody] RequestCartaDto dto)
        {
            var cartas = await _cartaService.SolicitarCartas(dto.IdJuego, dto.IdUsuario, dto.CantidadCartasSolicitadas, dto.EsCrupier);
            await _servicio.AddDetallesJuegos(cartas, dto.IdJuego, dto.EsCrupier);
            return Ok(cartas);
        }
    }
}
