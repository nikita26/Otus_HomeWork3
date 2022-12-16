using AutoMapper;
using Domain.Entities;
using Services.Abstractons;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDto Create(UserDto user)
        {
            var nU = _userRepository.Add(_mapper.Map<User>(user));
            _userRepository.SaveChanges();
            return _mapper.Map<UserDto>(nU);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAll().ToList());
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.Get(id));
        }

        public bool Update(UserDto comment)
        {
            throw new NotImplementedException();
        }
        public UserDto? FindUser(int id, string login)
        {
            return _mapper.Map<UserDto>(_userRepository.FindUser(id, login));
        }

    }
}