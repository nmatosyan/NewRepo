namespace OnlineShop.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderProduct> OrderProducts { get; set; } = new();
}
