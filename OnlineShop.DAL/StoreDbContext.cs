using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.DAL;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Product>()
    //        .Property(p => p.Id)
    //        .ValueGeneratedOnAdd();
    //}

    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
}