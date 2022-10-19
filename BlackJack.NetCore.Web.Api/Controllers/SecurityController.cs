using BlackJack.NetCore.Web.Api.Dtos.Security;
using BlackJack.NetCore.Web.Api.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using BlackJack.NetCore.Web.Api.Helpers;

namespace BlackJack.NetCore.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _config;

        public SecurityController(ISecurityService securityService,
            IConfiguration config)
        {
            _securityService = securityService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarUsuarioDto userForRegisterDto)
        {
            if (userForRegisterDto.FechaNacimiento.CalcularEdad() < 18)
                return BadRequest("Su edad es menor a 18 años. Este juego es solo para mayores de edad.");

            if (await _securityService.UsuarioExiste(userForRegisterDto.Email))
                return BadRequest("El usuario/correo electrónico ya esta registrado.");

            var userToCreate = await _securityService.RegistrarUsuario(userForRegisterDto, userForRegisterDto.Password);

            DetalleUsuarioDto user = await _securityService.GetUsuario(userToCreate.IdUsuario);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto userForLoginDto)
        {
            var userFromRepo = await _securityService.Login(userForLoginDto.Email.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(double.Parse(_config.GetSection("AppSettings:Expires").Value)),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var user = ((ListadoUsuarioDto)userFromRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}
