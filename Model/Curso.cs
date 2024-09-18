using Microsoft.AspNetCore.Identity;

namespace WebApi.Model
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdadeMinimaEmAnos { get; set; }
    }
}
