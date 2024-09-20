using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model.Entidades;
using WebApi.Model.Responses;
using WebApi.Repositories.Interfaces;

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
 
            return Ok(new LoginUsuarioResponse { Token = token.ToString(), HttpCode = StatusCodes.Status200OK }); 
        }
    }
}