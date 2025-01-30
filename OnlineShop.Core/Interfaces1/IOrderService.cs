using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces1;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
}
