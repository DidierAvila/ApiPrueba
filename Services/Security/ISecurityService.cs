using ApiPrueba.Dtos.Users;

namespace ApiPrueba.Services.Security
{
    public interface ISecurityService
    {
        Task<LoginResponse> Login(LoginRequest autorizacion, CancellationToken cancellationToken);
    }
}