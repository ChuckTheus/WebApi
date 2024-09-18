using WebApi.Model;

namespace WebApi.Repositories.Interfaces
{
    public interface ICursoRepositorio
    {
        void Matricular(Aluno aluno, Curso curso);
    }
}
