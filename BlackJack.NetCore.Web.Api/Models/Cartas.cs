using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class Cartas
    {
        public Cartas()
        {
            UsuariosCartasJuegos = new HashSet<UsuariosCartasJuegos>();
        }

        public int IdCarta { get; set; }
        public int Numero { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<UsuariosCartasJuegos> UsuariosCartasJuegos { get; set; }
    }
}
