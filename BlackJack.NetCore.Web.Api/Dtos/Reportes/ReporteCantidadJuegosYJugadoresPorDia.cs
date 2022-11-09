using System;

namespace BlackJack.NetCore.Web.Api.Dtos.Reportes
{
    public class ReporteCantidadJuegosYJugadoresPorDia
    {
        public string GameDate { get; set; }
        public int CantidadJuegos { get; set; }
        public int CantidadJugadores { get; set; }
    }
}
