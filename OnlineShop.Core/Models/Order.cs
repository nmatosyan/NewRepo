﻿using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public List<Product>? Products { get; set; } 
}
