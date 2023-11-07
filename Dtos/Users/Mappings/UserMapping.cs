using ApiPrueba.Models;
using AutoMapper;

namespace ApiPrueba.Dtos.Users.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, ReadUser>();
            CreateMap<ReadUser, User>();
            CreateMap<UpdateUser, User>();
        }
    }
}