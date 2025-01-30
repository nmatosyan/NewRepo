using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces1;

public interface IUserService
{
    Task<bool> RegisterUserAsync(User user);
    Task<bool> ValidateUserAsync(string username, string password);
}
