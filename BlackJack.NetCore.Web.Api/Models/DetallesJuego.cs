using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class DetallesJuego
    {
        public int IdDetalleJuego { get; set; }
        public int IdJuego { get; set; }
        public int IdCarta { get; set; }
        public bool EsCartaCrupier { get; set; }
        public int ValorCarta { get; set; }

        public virtual Cartas IdCartaNavigation { get; set; }
        public virtual Juegos IdJuegoNavigation { get; set; }
    }
}
