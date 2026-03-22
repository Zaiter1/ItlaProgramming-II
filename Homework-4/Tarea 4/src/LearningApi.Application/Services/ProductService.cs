using LearningApi.Application.Contract;
using LearningApi.Domain.Entities;
using LearningApi.Infraestructure.Interfaces;
using LearningApi.Models.Dtos;

namespace LearningApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAll()
        {
            var products = await _repository.GetAll();

            return products.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Nombre = p.ProductName,
                Precio = p.Price,
                Stock = p.Stock,
                DateReceived = p.DateReceived
            });
        }

        public async Task<ProductReadDto> GetById(int id)
        {
            var p = await _repository.GetById(id);

            if (p == null) return null;

            return new ProductReadDto
            {
                Id = p.Id,
                Nombre = p.ProductName,
                Precio = p.Price,
                Stock = p.Stock,
                DateReceived = p.DateReceived
            };
        }

        public async Task<bool> Create(ProductCreateDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre))
                return false;

            var product = new Product
            {
                ProductName = dto.Nombre,
                Price = dto.Precio,
                Stock = dto.Stock,
                DateReceived = dto.DateReceived
            };

            await _repository.Create(product);
            return true;
        }

        public async Task<bool> Update(int id, ProductUpdateDto dto)
        {
            var product = await _repository.GetById(id);

            if (product == null) return false;

            product.ProductName = dto.Nombre;
            product.Price = dto.Precio;
            product.Stock = dto.Stock;
            product.DateReceived = dto.DateReceived;

            await _repository.Update(product);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null) return false;

            await _repository.Delete(product);
            return true;
        }
    }
}