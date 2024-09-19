using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuariosController : Controller
    {
        [HttpGet("/")]
        public IActionResult Get([FromRoute] string nome)
        {
            //RETORNAR CandidatoVo PREENCHIDO
            return Ok();
        }
    }
}
