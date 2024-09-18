using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Infra
{
    public class IdentityApiDbContext : IdentityDbContext<Usuario>
    {
        public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options) : base(options) { }
    }
}
