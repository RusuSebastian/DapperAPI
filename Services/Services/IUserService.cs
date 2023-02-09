using Services.Dtos;

namespace Services.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetUsers();
        Task<UserDto> GetUserById(Guid userID);
        void AddUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(Guid userID);
    }
}
