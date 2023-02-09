using AutoMapper;
using Data.Entities;
using Data.Repository;
using Services.Dtos;
namespace Services.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddUser(UserDto user)
        {
            var userDto = _mapper.Map<User>(user);
            _userRepository.AddUserAsync(userDto);
        }

        public void DeleteUser(Guid userID)
        {
            _userRepository.DeleteUserAsync(userID);
        }

        public async Task<UserDto> GetUserById(Guid ID_User)
        {
            var user = _mapper.Map<UserDto>(await _userRepository.FindUserByIdAsync(ID_User));
            return user;
        }

        public async Task<ICollection<UserDto>> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(await _userRepository.GetAllUsersAsync());
            return users;
        }

        public void UpdateUser(UserDto user)
        {
            var userDto = _mapper.Map<User>(user);
            _userRepository.UpdateUserAsync(userDto);
        }
    }
}
