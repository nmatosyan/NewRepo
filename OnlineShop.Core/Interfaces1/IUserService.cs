using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces1;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<bool> RegisterUserAsync(User user);
    Task<bool> ValidateUserAsync(string username, string password);
    Task<User> GetUserByIdAsync(int id);
}
