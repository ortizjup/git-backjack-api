using BlackJack.NetCore.Web.Api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace BlackJack.NetCore.Web.Api.Dtos.Security
{
    public class DetalleUsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }


        public static implicit operator DetalleUsuarioDto(Usuarios entity)
        {
            return new DetalleUsuarioDto
            {
                Id = entity.IdUsuario,
                Apellido = entity.Apellido,
                Nombre = entity.Nombre,
                Email = entity.Email,
                PhotoUrl = entity.PhotoUrl
            };
        }
    }
}
