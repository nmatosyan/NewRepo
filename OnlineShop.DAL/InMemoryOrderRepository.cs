using OnlineShop.Core;
using OnlineShop.Models;

namespace OnlineShop.DAL;
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new List<Order>();

    public void CreateOrder(Order order)
    {
        order.Id = _orders.Count + 1;
        order.OrderDate = DateTime.UtcNow;
        _orders.Add(order);
    }

    public Order GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

    public IEnumerable<Order> GetAllOrders() => _orders;

   
}
