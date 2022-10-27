using BlackJack.NetCore.Web.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.NetCore.Web.Api.Dtos.Juego
{
    public class JugadorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Score { get; set; }
        public List<CartaDto> Cartas { get; set; }

        public static implicit operator JugadorDto(Usuarios usuario)
        {
            if (usuario == null)
                return null;

            return new JugadorDto
            {
                Id = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Score = usuario.Juegos.Where(x => x.Activo)
                .SelectMany(s => s.DetallesJuego)
                .Where(s => !s.EsCartaCrupier)
                .Sum(x => x.ValorCarta)
            };
        }
    }
}
