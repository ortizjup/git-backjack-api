using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.Models
{
    public partial class Valores
    {
        public Valores()
        {
            CartasValores = new HashSet<CartasValores>();
        }

        public int IdValor { get; set; }
        public int Valor { get; set; }

        public virtual ICollection<CartasValores> CartasValores { get; set; }
    }
}
