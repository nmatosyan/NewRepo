using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly StoreDbContext _context;

    public OrdersController(StoreDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetOrders(int userId)
    {
        var orders = await _context.Orders
                                   .Where(o => o.UserId == userId)
                                   .ToListAsync();
        return Ok(orders);
    }
}

