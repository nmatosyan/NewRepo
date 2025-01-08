using OnlineShop.Models;
using OnlineShop.Core;

namespace OnlineShop.BLL;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public void PlaceOrder(Order order)
    {
        foreach (var item in order.Items)
        {
            var product = _productRepository.GetProductById(item.ProductId);
            if (product == null || product.Stock < item.Quantity)
                throw new InvalidOperationException($"Product {item.ProductName} is not available in sufficient quantity.");

            product.Stock -= item.Quantity;
            _productRepository.UpdateProduct(product);
        }

        _orderRepository.CreateOrder(order);
    }
}
