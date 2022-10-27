namespace BlackJack.NetCore.Web.Api.Dtos.Juego.Request
{
    public class BaseRequestDto
    {
        public int IdJuego { get; set; }
        public int IdUsuario { get; set; }
        public bool EsCrupier { get; set; }
    }
}
