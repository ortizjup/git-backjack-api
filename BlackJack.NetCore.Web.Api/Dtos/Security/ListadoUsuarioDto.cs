using BlackJack.NetCore.Web.Api.Models;
using System;

namespace BlackJack.NetCore.Web.Api.Dtos.Security
{
    public class ListadoUsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string PhotoUrl { get; set; }

        public static implicit operator ListadoUsuarioDto(Usuarios entity)
        {
            return new ListadoUsuarioDto
            {
                Id = entity.IdUsuario,
                Email = entity.Email,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                PhotoUrl = entity.PhotoUrl
            };
        }
    }
}
