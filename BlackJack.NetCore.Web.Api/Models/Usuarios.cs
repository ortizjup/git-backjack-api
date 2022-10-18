using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosCartasJuegos = new HashSet<UsuariosCartasJuegos>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public byte[] HashContraseña { get; set; }

        public virtual ICollection<UsuariosCartasJuegos> UsuariosCartasJuegos { get; set; }
    }
}
