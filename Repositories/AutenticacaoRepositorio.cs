using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Infra;
using WebApi.Model;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class AutenticacaoRepositorio : IAutenticacaoRepositorio
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _config;

        public AutenticacaoRepositorio
        (
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IConfiguration config
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<string> AutenticarAsync(LoginRequest loginRequest)
        {
            var usuario = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (usuario == null)
                return null;

            var checarLogin = await _signInManager.CheckPasswordSignInAsync(usuario, loginRequest.Password, false);

            if (!checarLogin.Succeeded)
                return null;
            else
                return GerarToken(usuario);
        }

        public string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
