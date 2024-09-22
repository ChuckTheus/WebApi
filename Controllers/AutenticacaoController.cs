using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories.Interfaces;
using WebApi.ViewObjects;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        
        public AutenticacaoController(IAutenticacaoRepositorio autenticacaoRepositorio)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AutenticarAsync([FromBody] LoginRequest loqinRequest)
        {
            var token = await _autenticacaoRepositorio.AutenticarAsync(loqinRequest);

            if (token == null)
                return Unauthorized(new { mensagem = "Login ou Senha inválidos" });

            return Ok(new LoginUsuarioResponse { Token = token.ToString() }); 
        }
    }
}