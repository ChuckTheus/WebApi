using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApi.Model.Entidades;

namespace WebApi.Infra
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Usuario>().HasData(new Usuario
            {
                Id = "1",
                Nome = "Matheus Freire de Oliveira",
                Email = "candidato@softlabsolucoes.com.br",
                Senha = "Senha@Forte#123",
                Departamento = "Seleção 2024.1"
            });
        }
    }
}
