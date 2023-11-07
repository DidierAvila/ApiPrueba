using ApiPrueba.DbContexts;
using ApiPrueba.Dtos.Users;
using ApiPrueba.Models;
using ApiPrueba.Repositories.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Services.Users
{
    public class UserService : IUserService
    {
        private readonly PruebasDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public UserService(PruebasDbContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _UserRepository = userRepository;
        }

        public async Task<ReadUser> Create(CreateUser createUser, CancellationToken cancellationToken)
        {
            User EntityUser = _mapper.Map<CreateUser, User>(createUser);
            await _UserRepository.Create(EntityUser);
            return null;
        }

        public async Task<ReadUser> Get(int id, CancellationToken cancellationToken)
        {
            User CurrentUser = await _UserRepository.GetById(id);
            if (CurrentUser != null)
            {
                var dto = _mapper.Map<User, ReadUser>(CurrentUser);
                return dto;
            }
            return null;
        }

        public async Task<ReadUser> Update(UpdateUser updateRequest, CancellationToken cancellationToken)
        {
            User entity = await _UserRepository.GetById(updateRequest.Id);
            entity = _mapper.Map<UpdateUser, User>(updateRequest, entity);
            await _UserRepository.Update(entity.Id, entity);

            ReadUser dto = _mapper.Map<User, ReadUser>(entity);
            return dto;
        }

        public async Task<ICollection<ReadUser>> GetAll(CancellationToken cancellationToken)
        {
            ICollection<User> CurrentUsers = await _context.Users.ToListAsync(cancellationToken);
            if (CurrentUsers != null)
            {
                ICollection<ReadUser> readUser = _mapper.Map<ICollection<User>, List<ReadUser>>(CurrentUsers);
                return readUser;
            }
            return null;
        }
    }
}