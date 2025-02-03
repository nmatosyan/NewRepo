namespace OnlineShop.Core.DTO;

public class CreateOrderDto
{
    public int UserId { get; set; }
    public List<CreateOrderProductDto> Products { get; set; }
}
