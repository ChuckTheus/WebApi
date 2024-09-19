using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Model.Entidades;

namespace WebApi.Infra
{
    public class IdentityApiDbContext : IdentityDbContext<Usuario>
    {
        public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options) : base(options) { }
    }
}
