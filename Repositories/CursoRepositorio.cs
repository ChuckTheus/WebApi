using WebApi.Infra;
using WebApi.Model;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly ApplicationDbContext _applicationContext;
        
        public CursoRepositorio(ApplicationDbContext businessContext)
        {
            _applicationContext = businessContext;
        }
        
        public void Matricular(Aluno aluno, Curso curso)
        {
            if (curso.IdadeMinimaEmAnos.HasValue && aluno.DataDeNascimento.AddYears(curso.IdadeMinimaEmAnos.Value) > DateTime.Now)
                throw new ArgumentException("O Aluno não possui a idade mínima para fazer o curso");

            var matriculaExistente = _applicationContext.Matriculas
            .Any(m => m.AlunoId == aluno.Id && m.CursoId == curso.Id);
            if (matriculaExistente)
            {
                throw new ArgumentException("Aluno já está matriculado neste curso");
            }

            var matricula = new Matricula
            {
                Aluno = aluno,
                Curso = curso
            };

            _applicationContext.Matriculas.Add(new Matricula { Aluno = aluno, Curso = curso });

            _applicationContext.SaveChanges();
        }
    }
}
