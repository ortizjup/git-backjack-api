using BlackJack.NetCore.Web.Api.Dtos.Juego;
using System;

namespace BlackJack.NetCore.Web.Api.Dtos.Reportes
{
    public class PartidaDto
    {
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public int ScoreCrupier { get; set; }
        public int ScoreJugador { get; set; }
        public JugadorDto Jugador { get; set; }
    }
}
