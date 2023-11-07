using ApiPrueba.Repositories.Tokens;
using ApiPrueba.Repositories.Users;
using ApiPrueba.Services.Products;
using ApiPrueba.Services.Security;
using ApiPrueba.Services.Users;
using ApiPrueba.Services.Utilities;

namespace ApiPrueba.Extentions
{
    public static class ApiPruebaExtention
    {
        public static IServiceCollection AddApiPruebaExtention(this IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IUtilService, UtilService>();
            
            return services;
        }
    }
}