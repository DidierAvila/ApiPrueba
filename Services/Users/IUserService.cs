using ApiPrueba.Dtos.Users;

namespace ApiPrueba.Services.Users
{
    public interface IUserService
    {
        Task<ReadUser> Create(CreateUser createUser, CancellationToken cancellationToken);
        Task<ReadUser> Get(int id, CancellationToken cancellationToken);
        Task<ICollection<ReadUser>> GetAll(CancellationToken cancellationToken);
        Task<ReadUser> Update(UpdateUser updateRequest, CancellationToken cancellationToken);
    }
}