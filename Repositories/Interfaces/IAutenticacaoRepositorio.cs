using Microsoft.AspNetCore.Identity.Data;
using WebApi.Model;


namespace WebApi.Repositories.Interfaces
{
    public interface IAutenticacaoRepositorio
    {
        Task<string> AutenticarAsync(LoginRequest loginRequest);
    }
}
