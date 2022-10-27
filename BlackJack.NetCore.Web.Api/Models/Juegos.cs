using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class Juegos
    {
        public Juegos()
        {
            DetallesJuego = new HashSet<DetallesJuego>();
        }

        public int IdJuego { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string Description { get; set; }
        public bool? GanoJugador { get; set; }
        public int? ScoreJugador { get; set; }
        public int? ScoreCrupier { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetallesJuego> DetallesJuego { get; set; }
    }
}
