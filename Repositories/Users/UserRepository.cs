using ApiPrueba.DbContexts;
using ApiPrueba.Models;

namespace ApiPrueba.Repositories.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PruebasDbContext context) : base(context)
        {
        }
    }
}