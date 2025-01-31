using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces1;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var product = await _productService.GetAllProductsAsync();
        return Ok(product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        if (id <= 0) return BadRequest("The product id must be greater than zero");

        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createProduct = await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createProduct.Id }, createProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            await _productService.UpdateProductAsync(id, product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();        
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productService.DeleteProductAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        return NoContent();
    }
  
}