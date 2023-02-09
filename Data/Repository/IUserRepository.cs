using Data.Entities;

namespace Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> FindUserByIdAsync(Guid id);

        void AddUserAsync(User user);
        void UpdateUserAsync(User user);
        void DeleteUserAsync(Guid id);

    }
}
