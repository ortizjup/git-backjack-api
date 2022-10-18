using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class UsuariosCartasJuegos
    {
        public int IdCombination { get; set; }
        public int IdJuego { get; set; }
        public int IdCarta { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cartas IdCartaNavigation { get; set; }
        public virtual Juegos IdJuegoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
