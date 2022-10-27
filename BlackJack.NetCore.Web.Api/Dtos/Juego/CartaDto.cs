using BlackJack.NetCore.Web.Api.Models;
using System.Linq;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class CartaDto
    {
        public int Id { get; set; }
        public int Identificador { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public int[] Valores { get; set; }
        public int IdCategoria { get; set; }
        public CategoriaCartaDto CategoriaCartaDto { get; set; }

        public static implicit operator CartaDto(Cartas carta)
        {
            return new CartaDto
            {
                Id = carta.IdCarta,
                Identificador = carta.IdCarta,
                Numero = carta.Numero,
                Nombre = carta.Nombre,
                Valores = carta.CartasValores.Select(x => x.IdValorNavigation.Valor).ToArray(),
                IdCategoria = carta.IdCategoria,
                CategoriaCartaDto = carta.IdCategoriaNavigation
            };
        }
    }
}
