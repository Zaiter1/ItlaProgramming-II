//using LearningApi.Data.Entities;
using LearningApi.Models.Dtos;
using LearningApi.Models.Dtos;
using LearningApi.Persistence;
using LearningApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using LearningApi.Infraestructure.Interfaces;
//using Learning.Domain.Repository;


//Miguel Zaiter 2025-0928

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    //private readonly ApplicationDataContext _context;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    //public ProductController(ApplicationDataContext context,
    //    IMapper mapper,IProductRepository productRepository)
    //{
    //    //_context = context;
    //    _mapper = mapper;
    //    _productRepository = productRepository;
    //}


    public ProductController(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }


    // GET
    [HttpGet]
    public async Task<IActionResult> GetProductos()
    {
        var products = await _productRepository.GetAll();
        var result = _mapper.Map<List<ProductReadDto>>(products);
        return Ok(result);
    }
    //public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProductos()
    //{
    //    var products = await _context.Products.ToListAsync();

    //    var result = products.Select(p => new ProductReadDto
    //    {
    //        Id = p.Id,
    //        Nombre = p.ProductName,
    //        Precio = p.Price,
    //        Stock = p.Stock,
    //        DateReceived = p.DateReceived
    //    });

    //    return Ok(result);
    //}

    // GETBy Id
    //[HttpGet("{id}")]
    //public async Task<ActionResult<ProductReadDto>> GetProducto(int id)
    //{
    //    var product = await _context.Products.FindAsync(id);

    //    if (product == null)
    //        return NotFound();

    //    var result = new ProductReadDto
    //    {
    //        Id = product.Id,
    //        Nombre = product.ProductName,
    //        Precio = product.Price,
    //        Stock = product.Stock,
    //        DateReceived = product.DateReceived
    //    };

    //    return Ok(result);
    //}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetProducto(int id)
    {
        var product = await _productRepository.GetById(id);

        if (product == null)
            return NotFound();

        var result = _mapper.Map<ProductReadDto>(product);
        return Ok(result);
    }
    // post
    [HttpPost]
    //public async Task<ActionResult<ProductReadDto>> CreateProducto(ProductCreateDto dto)
    //{
    //    var product = new Product
    //    {
    //        ProductName = dto.Nombre,
    //        Price = dto.Precio,
    //        Stock = dto.Stock,
    //        DateReceived = dto.DateReceived
    //    };

    //    _context.Products.Add(product);
    //    await _context.SaveChangesAsync();

    //    var result = new ProductReadDto
    //    {
    //        Id = product.Id,
    //        Nombre = product.ProductName,
    //        Precio = product.Price,
    //        Stock = product.Stock,
    //        DateReceived = product.DateReceived
    //    };

    //    return CreatedAtAction(nameof(GetProducto), new { id = product.Id }, result);
    //}
    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> CreateProducto(ProductCreateDto dto)
    {
        var product = _mapper.Map<Product>(dto);

        var created = await _productRepository.Create(product);

        var result = _mapper.Map<ProductReadDto>(created);

        return CreatedAtAction(nameof(GetProducto), new { id = result.Id }, result);
    }
    // put
    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateProducto(int id, ProductUpdateDto dto)
    //{
    //    var product = await _context.Products.FindAsync(id);

    //    if (product == null)
    //        return NotFound();

    //    product.ProductName = dto.Nombre;
    //    product.Price = dto.Precio;
    //    product.Stock = dto.Stock;
    //    product.DateReceived = dto.DateReceived;

    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, ProductUpdateDto dto)
    {
        var product = await _productRepository.GetById(id);

        if (product == null)
            return NotFound();

        _mapper.Map(dto, product);

        await _productRepository.Update(product);

        return NoContent();
    }

    // delete
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteProducto(int id)
    //    {
    //        var product = await _context.Products.FindAsync(id);

    //        if (product == null)
    //            return NotFound();

    //        _context.Products.Remove(product);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var product = await _productRepository.GetById(id);

        if (product == null)
            return NotFound();

        await _productRepository.Delete(product);

        return NoContent();
    }
}


