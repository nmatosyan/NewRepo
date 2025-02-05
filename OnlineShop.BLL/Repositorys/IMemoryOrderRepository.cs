using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;
namespace OnlineShop.BLL.Repositorys;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new List<Order>();

    public void CreateOrder(Order order)
    {
        order.Id = _orders.Count + 1;
        order.OrderDate = DateTime.Now;
        _orders.Add(order);
    }

    public Order GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            throw new KeyNotFoundException($"Order with id {id} not found");
        }
        return order;
    }

    public IEnumerable<Order> GetAllOrders() => _orders;
}
