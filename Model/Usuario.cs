using Microsoft.AspNetCore.Identity;

namespace WebApi.Model
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
