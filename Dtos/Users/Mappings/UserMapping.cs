using ApiPrueba.Custom;
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
            CreateMap<CreateUser, User>().ForMember(dto => dto.Role, opt => opt.MapFrom(d => d.Role.ToString()));
        }
    }
}