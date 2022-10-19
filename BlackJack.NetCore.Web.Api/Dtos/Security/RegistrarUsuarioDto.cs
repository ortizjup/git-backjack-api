using System.ComponentModel.DataAnnotations;
using System;
using BlackJack.NetCore.Web.Api.Models;
using System.Security.AccessControl;

namespace BlackJack.NetCore.Web.Api.Dtos.Security
{
    public class RegistrarUsuarioDto
    {

        [Required(ErrorMessage = "Correo electrónico es un campo requerido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre debe ser de 4 a 50 caracteres de largo.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es un campo requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El usuario debe ser de 4 a 50 caracteres de largo.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento es un campo requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Contraseña es un campo requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La contraseña tiene que se entre 4 y 50 caracteres.")]
        public string Password { get; set; }


        public static implicit operator Usuarios(RegistrarUsuarioDto userForRegisterDto)
        {
            return new Usuarios
            {
                Email = userForRegisterDto.Email,
                Nombre = userForRegisterDto.Nombre,
                Apellido = userForRegisterDto.Apellido
            };
        }
    }
}
