using Microsoft.AspNetCore.Identity.Data;
using WebApi.Model;
using WebApi.Model.Entidades;
using WebApi.Model.Responses;

namespace WebApi.Repositories.Interfaces
{
    public interface IAutenticacaoRepositorio
    {
        string Autenticar(LoginRequest loginRequest);
        string GerarToken();
    }
}
