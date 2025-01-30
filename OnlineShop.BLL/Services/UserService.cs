using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;
using OnlineShop.DAL;
namespace OnlineShop.BLL.Services;

public class UserService : IUserService
{
    private readonly StoreDbContext _context;

    public UserService(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUserAsync(User user)
    {
        if (string.IsNullOrEmpty(user.PasswordHash))
            throw new ArgumentException("Password cannot be null or empty");

        user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ValidateUserAsync(string username, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user == null) return false;

        var hashedPassword = PasswordHasher.HashPassword(password);
        return user.PasswordHash == hashedPassword;
    }
}
