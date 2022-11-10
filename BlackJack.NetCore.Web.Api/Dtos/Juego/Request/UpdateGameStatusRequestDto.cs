namespace BlackJack.NetCore.Web.Api.Dtos.Juego.Request
{
    public class UpdateGameStatusRequestDto
    {
        public int idUsuario { get; set; }
        public int idJuego { get; set; }
        public int scoreJugador { get; set; }
        public int scoreCrupier { get; set; }
        public bool GanaJugador { get; set; }
        public bool EsEmpate { get; set; }
    }
}
