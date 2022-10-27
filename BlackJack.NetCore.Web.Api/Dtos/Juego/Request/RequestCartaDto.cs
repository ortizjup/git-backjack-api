namespace BlackJack.NetCore.Web.Api.Dtos.Juego.Request
{
    public class RequestCartaDto : BaseRequestDto
    {
        public bool EsCrupier { get; set; }
        public int CantidadCartasSolicitadas { get; set; }
    }
}
