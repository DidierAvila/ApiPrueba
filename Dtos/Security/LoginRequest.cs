
namespace ApiPrueba.Dtos.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static implicit operator LoginRequest(LoginResponse v)
        {
            throw new NotImplementedException();
        }
    }
}