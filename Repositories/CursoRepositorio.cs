using WebApi.Infra;
using WebApi.Model;
using WebApi.Model.Entidades;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly BusinessContext _businessContext;
        
        public CursoRepositorio(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }
        
        public void Matricular(Aluno aluno, Curso curso)
        {
            if (curso.IdadeMinimaEmAnos.HasValue && aluno.DataDeNascimento.AddYears(curso.IdadeMinimaEmAnos.Value) > DateTime.Now)
                throw new ArgumentException("O Aluno não possui a idade mínima para fazer o curso");
            
            _businessContext.Matriculas.Add(new Matricula { Aluno = aluno, Curso = curso });

            _businessContext.SaveChanges();
        }
    }
}
