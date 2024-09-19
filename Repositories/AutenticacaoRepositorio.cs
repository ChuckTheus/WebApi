using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using WebApi.Infra;
using WebApi.Model;
using WebApi.Model.Entidades;
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

        public bool Autenticar(LoginRequest loginRequest)
        {
            var usuario = _userManager.FindByEmailAsync(loginRequest.Email);

            bool validarSenha = _signInManager.CheckPasswordSignInAsync(usuario, loginRequest.Password, false);

        }

        public string GerarToken()
        {
            throw new NotImplementedException();
        }
    }
}
