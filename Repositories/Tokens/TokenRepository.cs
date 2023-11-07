using ApiPrueba.DbContexts;
using ApiPrueba.Models;

namespace ApiPrueba.Repositories.Tokens
{
    public class TokenRepository : RepositoryBase<Token>, ITokenRepository
    {
        public TokenRepository(PruebasDbContext context) : base(context)
        {
        }
    }
}