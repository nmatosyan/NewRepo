using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL;
using OnlineShop.Core;
using OnlineShop.DAL;

namespace OnlineShop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // services
        builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();
        builder.Services.AddScoped<IOrderRepository, InMemoryOrderRepository>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<OrderService>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<StoreDbContext>(options =>
            options.UseNpgsql(connectionString));

        // add controllers
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
