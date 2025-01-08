using OnlineShop.Models;
namespace OnlineShop.Core;

public interface IOrderRepository
{
    IEnumerable<Order> GetAllOrders();
    void CreateOrder(Order order);
    Order GetById(int id);
}
