using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Model;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

        if (!userManager.Users.Any())
        {
            var user = new Usuario
            {
                UserName = "candidato@softlabsolucoes.com.br",
                Email = "candidato@softlabsolucoes.com.br",
                Nome = "Matheus Freire de Oliveira",
                Departamento = "Seleção 2024.1"
            };

            await userManager.CreateAsync(user, "Senha@Forte#123");
        }
    }
}
