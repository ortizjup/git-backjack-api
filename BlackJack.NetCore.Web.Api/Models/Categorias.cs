using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Cartas = new HashSet<Cartas>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string NewTablecol { get; set; }

        public virtual ICollection<Cartas> Cartas { get; set; }
    }
}
