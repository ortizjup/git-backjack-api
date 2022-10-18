﻿using System;
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
            UsuariosCartasJuegos = new HashSet<UsuariosCartasJuegos>();
        }

        public int IdJuego { get; set; }
        public bool? Activo { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UsuariosCartasJuegos> UsuariosCartasJuegos { get; set; }
    }
}
