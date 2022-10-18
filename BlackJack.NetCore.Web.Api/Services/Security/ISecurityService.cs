using BlackJack.NetCore.Web.Api.Models;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Security
{
    public interface ISecurityService
    {
        Task<Usuarios> Login(string email, string password);
        Task<Usuarios> RegistrarUsuario(Usuarios user, string password);
        Task<bool> UsuarioExiste(string email);
        Task<Usuarios> GetUsuario(int id);
    }
}