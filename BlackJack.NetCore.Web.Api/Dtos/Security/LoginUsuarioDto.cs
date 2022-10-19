using System.ComponentModel.DataAnnotations;

namespace BlackJack.NetCore.Web.Api.Dtos.Security
{
    public class LoginUsuarioDto
    {
        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El usuario debe tener 4 caracteres como minimo y 50 como maximo.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La contraseña debe tener 4 caracteres como minimo y 50 como maximo.")]
        public string Password { get; set; }
    }
}
