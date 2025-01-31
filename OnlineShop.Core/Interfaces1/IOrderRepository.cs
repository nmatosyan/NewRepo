using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces1;

public interface IOrderRepository
{
    IEnumerable<Order> GetAllOrders();
    void CreateOrder(Order order);
    Order GetById(int id);
}
