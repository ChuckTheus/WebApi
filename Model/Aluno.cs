using Microsoft.AspNetCore.Identity;

namespace WebApi.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
