using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;
namespace OnlineShop.BLL.Repositorys;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public IEnumerable<Product> GetAllProducts() => _products;

    public Product GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found");
        }
        return product;
    }

    public void AddProduct(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = GetProductById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = GetProductById(id);
        if (product != null)
        {
            {
                _products.Remove(product);
            }
        }
    }
}
