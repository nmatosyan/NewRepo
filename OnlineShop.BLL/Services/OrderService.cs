using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO;
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

    public async Task<Order> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order
        {
            UserId = createOrderDto.UserId,
            OrderDate = DateTime.UtcNow
        };

        foreach (var productDto in createOrderDto.Products)
        {
            var product = await _context.Products.FindAsync(productDto.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productDto.ProductId} not faund.");
            }

            var orderProduct = new OrderProduct
            {
                ProductId = productDto.ProductId,
                Product = product,
                Quantity = productDto.Quantity,
            };
            order.OrderProducts.Add(orderProduct);
        }

        _context.Orders.Add(order);
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception($"Excaption saving in database: {ex.InnerException?.Message}", ex);
        }

        return order;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
       .Include(o => o.OrderProducts)
       .ThenInclude(op => op.Product)
       .FirstOrDefaultAsync(o => o.Id == id);
        if (id <= 0)
        {
            throw new KeyNotFoundException("Id most be greater than zero");
        }

        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        return order;
    }

    public async Task UpdateOrderAsync(int id, UpdateOrderDto updateOrderDto)
    {
        var order = await _context.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefaultAsync(o => o.Id == id);
           
        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        order.OrderProducts.Clear();

        foreach (var productDto in updateOrderDto.Products)
        {
            var orderProduct = new OrderProduct
            {
                ProductId = productDto.ProductId,
                Quantity = productDto.Quantity,
            };
            order.OrderProducts.Add(orderProduct);
        }

        await _context.SaveChangesAsync();
    }
}