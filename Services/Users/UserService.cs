using ApiPrueba.Dtos.Users;
using ApiPrueba.Models;
using ApiPrueba.Repositories.Users;
using AutoMapper;

namespace ApiPrueba.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _UserRepository = userRepository;
        }

        public async Task<ReadUser> Create(CreateUser createUser, CancellationToken cancellationToken)
        {
            User EntityUser = _mapper.Map<CreateUser, User>(createUser);
            await _UserRepository.Create(EntityUser, cancellationToken);
            return null;
        }

        public async Task<ReadUser> Get(int id, CancellationToken cancellationToken)
        {
            User CurrentUser = await _UserRepository.GetByID(id, cancellationToken);
            if (CurrentUser != null)
            {
                return _mapper.Map<User, ReadUser>(CurrentUser);
            }
            return null;
        }

        public async Task<ReadUser> Update(UpdateUser updateRequest, CancellationToken cancellationToken)
        {
            User entity = await _UserRepository.GetByID(updateRequest.Id, cancellationToken);
            entity = _mapper.Map<UpdateUser, User>(updateRequest, entity);
            await _UserRepository.Update(entity, cancellationToken);

            return _mapper.Map<User, ReadUser>(entity);
        }

        public async Task<ICollection<ReadUser>> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<User> CurrentUsers = await _UserRepository.GetAll(cancellationToken);
            if (CurrentUsers != null)
            {
                return _mapper.Map<IEnumerable<User>, List<ReadUser>>(CurrentUsers);
            }
            return null;
        }
    }
}