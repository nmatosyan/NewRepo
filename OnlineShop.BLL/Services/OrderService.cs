using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;
using OnlineShop.DAL;
namespace OnlineShop.BLL.Services;

public class OrderService : IOrderService
{
    private readonly StoreDbContext _context;

    public OrderService(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return await _context.Orders
                             .Where(o => o.UserId == userId)
                             .ToListAsync();
    }
}
