using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

        if (await userManager.FindByEmailAsync("candidato@softlabsolucoes.com.br") == null)
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
