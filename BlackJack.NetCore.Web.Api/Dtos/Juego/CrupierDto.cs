using BlackJack.NetCore.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class CrupierDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public List<CartaDto> Cartas { get; set; }

        public static implicit operator CrupierDto(Usuarios crupier)
        {
            return new CrupierDto
            {
                Id = 0,
                Score = crupier.Juegos.Where(x => x.Activo)
                .SelectMany(x => x.DetallesJuego)
                .Where(s => s.EsCartaCrupier)
                .Sum(x => x.ValorCarta),
                Cartas = crupier.Juegos.Where(x => x.Activo).SelectMany(x => x.DetallesJuego)
                .Select(x => new CartaDto
                {
                    Id = x.IdCarta,
                    IdCategoria = x.IdCartaNavigation.IdCategoria,
                    Identificador = x.IdCarta,
                    Nombre = x.IdCartaNavigation.Nombre,
                    Valores = x.IdCartaNavigation.CartasValores.Select(s => s.IdValorNavigation.Valor).ToArray(),
                    CategoriaCartaDto = x.IdCartaNavigation.IdCategoriaNavigation,
                    Numero = x.IdCartaNavigation.Numero
                }).ToList()
            };
        }
    }
}
