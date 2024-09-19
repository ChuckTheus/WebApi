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
            string token = _autenticacaoRepositorio.Autenticar(loqinRequest);
 
            return Ok(new LoginUsuarioResponse { Token = token, HttpCode = StatusCodes.Status200OK }); 
        }
    }
}