using BlackJack.NetCore.Web.Api.DataContext;
using BlackJack.NetCore.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlackJack.NetCore.Web.Api.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly TpiBlackJackDbContext _context;

        public SecurityService(TpiBlackJackDbContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> Login(string email, string password)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            if (!VerificarPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<Usuarios> RegistrarUsuario(Usuarios user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CrearPasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UsuarioExiste(string email)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }

        public async Task<Usuarios> GetUsuario(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        #region PrivateMethods

        private bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwrodSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwrodSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }
        #endregion
    }
}
