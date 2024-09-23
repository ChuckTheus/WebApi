using Microsoft.EntityFrameworkCore;
using WebApi.Infra;
using WebApi.Model;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly BusinessContext _context;

        public CursoRepositorio(BusinessContext context)
        {
            _context = context;
        }
        
        public void Matricular(Aluno aluno, Curso curso)
        {
            if (curso.IdadeMinimaEmAnos.HasValue && aluno.DataDeNascimento.AddYears(curso.IdadeMinimaEmAnos.Value) > DateTime.Now)
                throw new ArgumentException("O Aluno não possui a idade mínima para fazer o curso");

            var matriculaExistente = _context.Set<Matricula>().Any(m => m.AlunoId == aluno.Id && m.CursoId == curso.Id);
            
            if (matriculaExistente)
            {
                throw new ArgumentException("Aluno já está matriculado neste curso");
            }

            var matricula = new Matricula
            {
                AlunoId = aluno.Id,
                Aluno = aluno,
                CursoId = curso.Id,
                Curso = curso
            };

            _context.Set<Matricula>().Add(new Matricula { Aluno = aluno, Curso = curso });

            _context.SaveChanges();
        }
    }
}
