namespace OnlineShop.Core.Models;

public class OrderProduct
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quontity { get; set; }
}
