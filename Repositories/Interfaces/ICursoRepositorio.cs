using WebApi.Model.Entidades;

namespace WebApi.Repositories.Interfaces
{
    public interface ICursoRepositorio
    {
        void Matricular(Aluno aluno, Curso curso);
    }
}
