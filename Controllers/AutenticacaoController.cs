using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class AutenticacaoController : Controller
    {
        [HttpPost]
        [Route("/autenticar")]
        public ActionResult<string> Autenticar(LoginRequest loqinRequest)
        {
           /* var usuario = _repositorio.Autenticar(loqinRequest);
            if (usuario = null)
            { 
                return Unauthorized("Login ou Senha inválidos");
            }

            string token = _jwtService.GerarToken(usuario);*/
            return Ok();
        }
    }
}