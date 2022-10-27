using BlackJack.NetCore.Web.Api.Models;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class CategoriaCartaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public static implicit operator CategoriaCartaDto(Categorias categorias)
        {
            return new CategoriaCartaDto
            {
                Id = categorias.IdCategoria,
                Descripcion = categorias.Descripcion,
                Codigo = categorias.Codigo
            };
        }
    }
}
