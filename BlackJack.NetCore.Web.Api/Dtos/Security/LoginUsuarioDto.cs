using System.ComponentModel.DataAnnotations;

namespace BlackJack.NetCore.Web.Api.Dtos.Security
{
    public class LoginUsuarioDto
    {
        [Required(ErrorMessage = "You must provide a username")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username max length allow is between 4 and 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be provided")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Password max length allow is 50 characters")]
        public string Password { get; set; }
    }
}
