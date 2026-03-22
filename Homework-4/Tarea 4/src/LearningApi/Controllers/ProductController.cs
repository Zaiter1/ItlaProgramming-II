
using AutoMapper;
using LearningApi.Application.Contract;
using LearningApi.Application.Services;
using LearningApi.Domain.Entities;
using LearningApi.Infraestructure.Interfaces;
using LearningApi.Models.Dtos;
using LearningApi.Models.Dtos;
using LearningApi.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LearningApi.Application.Services;

//Miguel Zaiter 2025-0928

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  
    //private readonly IMapper _mapper;
    //private readonly IProductRepository _productRepository;
    private readonly ProductService _service;



    //public ProductController(IMapper mapper, IProductRepository productRepository)
    //{
    //    _mapper = mapper;
    //    _productRepository = productRepository;
    //}
    //public ProductController(IMapper mapper, ProductService service)
    //{
    //    _mapper = mapper;
    //    _service = service;
    //}

    public ProductController(ProductService service)
    {
        _service = service;
    }

    // GET
    //[HttpGet]
    //public async Task<IActionResult> GetProductos()
    //{
    //    //var products = await _productRepository.GetAll();
    //    var products = await _service.GetAll();
    //    var result = _mapper.Map<List<ProductReadDto>>(products);
    //    return Ok(result);
    //}
    [HttpGet]
    public async Task<IActionResult> GetProductos()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    //[HttpGet("{id}")]
    //public async Task<ActionResult<ProductReadDto>> GetProducto(int id)
    //{
    //    var product = await _productRepository.GetById(id);

    //    if (product == null)
    //        return NotFound();

    //    var result = _mapper.Map<ProductReadDto>(product);
    //    return Ok(result);
    //}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetProducto(int id)
    {
        var result = await _service.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]

    //[HttpPost]
    //public async Task<ActionResult<ProductReadDto>> CreateProducto(ProductCreateDto dto)
    //{
    //    var product = _mapper.Map<Product>(dto);

    //    var created = await _productRepository.Create(product);

    //    var result = _mapper.Map<ProductReadDto>(created);

    //    return CreatedAtAction(nameof(GetProducto), new { id = result.Id }, result);
    //}
    [HttpPost]
    public async Task<IActionResult> CreateProducto(ProductCreateDto dto)
    {
        var success = await _service.Create(dto);

        if (!success)
            return BadRequest("Datos inválidos");

        return Ok();
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateProducto(int id, ProductUpdateDto dto)
    //{
    //    var product = await _productRepository.GetById(id);

    //    if (product == null)
    //        return NotFound();

    //    _mapper.Map(dto, product);

    //    await _productRepository.Update(product);

    //    return NoContent();
    //}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, ProductUpdateDto dto)
    {
        var success = await _service.Update(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteProducto(int id)
    //{
    //    var product = await _productRepository.GetById(id);

    //    if (product == null)
    //        return NotFound();

    //    await _productRepository.Delete(product);

    //    return NoContent();
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var success = await _service.Delete(id);

        if (!success)
            return NotFound();

        return NoContent();
    }

}


