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
            CartasValores = new HashSet<CartasValores>();
            DetallesJuego = new HashSet<DetallesJuego>();
        }

        public int IdCarta { get; set; }
        public int Numero { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public bool ShowBack { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual ICollection<CartasValores> CartasValores { get; set; }
        public virtual ICollection<DetallesJuego> DetallesJuego { get; set; }
    }
}
