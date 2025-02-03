using OnlineShop.Core.DTO;
using OnlineShop.Core.Models;
namespace OnlineShop.Core.Interfaces1;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto);
    Task DeleteOrderAsync(int id);
}

