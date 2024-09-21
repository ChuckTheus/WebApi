using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories.Interfaces;
using WebApi.ViewObjects;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        
        public AutenticacaoController(IAutenticacaoRepositorio autenticacaoRepositorio)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
        }

        [HttpPost]
        [Route("/[action]")]
        public IActionResult Autenticar([FromBody] LoginRequest loqinRequest)
        {
            var token = _autenticacaoRepositorio.AutenticarAsync(loqinRequest);
 
            return Ok(new LoginUsuarioResponse { Token = token.ToString() }); 
        }
    }
}