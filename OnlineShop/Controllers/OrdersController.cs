using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;
namespace OnlineShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createOrder = await _orderService.CreateOrderAsync(order);
        return Ok(createOrder);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetOrders(int userId)
    {
        var orders = await _orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }

}

