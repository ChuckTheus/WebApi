﻿using Microsoft.AspNetCore.Identity;

namespace WebApi.Model
{
    public class Matricula
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
