using Microsoft.AspNetCore.Identity;

namespace WebApi.Model.Entidades
{
    public class Matricula
    {
        public long Id { get; set; }
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
    }
}
