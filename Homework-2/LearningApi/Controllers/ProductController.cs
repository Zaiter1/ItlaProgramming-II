using LearningApi.Data.Entities;
using LearningApi.Models.Dtos;
using LearningApi.Models.Dtos.LearningApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


//Miguel Zaiter 2025-0928

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDataContext _context;

    public ProductController(ApplicationDataContext context)
    {
        _context = context;
    }

    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProductos()
    {
        var products = await _context.Products.ToListAsync();

        var result = products.Select(p => new ProductReadDto
        {
            Id = p.Id,
            Nombre = p.ProductName,
            Precio = p.Price,
            Stock = p.Stock,
            DateReceived = p.DateReceived
        });

        return Ok(result);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetProducto(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        var result = new ProductReadDto
        {
            Id = product.Id,
            Nombre = product.ProductName,
            Precio = product.Price,
            Stock = product.Stock,
            DateReceived = product.DateReceived
        };

        return Ok(result);
    }

    // post
    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> CreateProducto(ProductCreateDto dto)
    {
        var product = new Product
        {
            ProductName = dto.Nombre,
            Price = dto.Precio,
            Stock = dto.Stock,
            DateReceived = dto.DateReceived
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = new ProductReadDto
        {
            Id = product.Id,
            Nombre = product.ProductName,
            Precio = product.Price,
            Stock = product.Stock,
            DateReceived = product.DateReceived
        };

        return CreatedAtAction(nameof(GetProducto), new { id = product.Id }, result);
    }

    // puy
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, ProductUpdateDto dto)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        product.ProductName = dto.Nombre;
        product.Price = dto.Precio;
        product.Stock = dto.Stock;
        product.DateReceived = dto.DateReceived;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}



