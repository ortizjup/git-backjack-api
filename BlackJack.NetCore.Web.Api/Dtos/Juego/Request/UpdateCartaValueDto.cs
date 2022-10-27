namespace BlackJack.NetCore.Web.Api.Dtos.Juego.Request
{
    public class UpdateCartaValueDto
    {
        public int IdJuego { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarta { get; set; }
        public int ValorSolicitado { get; set; }
    }
}
