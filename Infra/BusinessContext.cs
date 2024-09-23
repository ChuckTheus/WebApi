using Microsoft.EntityFrameworkCore;

namespace WebApi.Infra
{
    public class BusinessContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public BusinessContext(DbContextOptions<BusinessContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>()
                .HasKey(m => new { m.AlunoId, m.CursoId });

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany()  
                .HasForeignKey(m => m.AlunoId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany()  
                .HasForeignKey(m => m.CursoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
