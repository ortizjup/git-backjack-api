using BlackJack.NetCore.Web.Api.Models;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class DetallesJuegoDto
    {
        public int Id { get; set; }
        public int IdJuego { get; set; }
        public int IdCarta { get; set; }
        public bool EsCartaCrupier { get; set; }
        public int ValorCarta { get; set; }

        public CartaDto CartaDto { get; set; }

        public static implicit operator DetallesJuegoDto(DetallesJuego detalles)
        {
            return new DetallesJuegoDto
            {
                Id = detalles.IdDetalleJuego,
                IdJuego = detalles.IdJuego,
                IdCarta = detalles.IdCarta,
                EsCartaCrupier = detalles.EsCartaCrupier,
                ValorCarta = detalles.ValorCarta,
                CartaDto = detalles.IdCartaNavigation
            };
        }

        public static implicit operator DetallesJuego(DetallesJuegoDto dto)
        {
            return new DetallesJuegoDto
            {
                Id = dto.Id,
                IdJuego = dto.IdJuego,
                IdCarta = dto.IdCarta,
                EsCartaCrupier = dto.EsCartaCrupier,
                ValorCarta =  dto.ValorCarta
            };
        }
    }
}
