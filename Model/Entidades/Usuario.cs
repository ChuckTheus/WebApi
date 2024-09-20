﻿using Microsoft.AspNetCore.Identity;

namespace WebApi.Model.Entidades
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
    }
}
