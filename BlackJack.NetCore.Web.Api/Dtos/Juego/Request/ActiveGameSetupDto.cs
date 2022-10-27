using System.Collections.Generic;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego.Request
{
    public class ActiveGameSetupDto
    {
        public int idUsuario { get; set; }
        public int idJuego { get; set; }
        public bool Active { get; set; }
        public JugadorDto Jugador { get; set; }
        public List<CartaDto> CartasUsuario { get; set; }
        public List<CartaDto> CartasCrupier { get; set; }
    }
}
