using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult Autenticar() 
        { 
            return Ok();
        }
    }
}
