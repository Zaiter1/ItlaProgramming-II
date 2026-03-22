using System;
using System.Collections.Generic;
using System.Text;
using global::LearningApi.Domain.Entities;
using LearningApi.Domain.Entities;


namespace LearningApi.Infraestructure.Interfaces 
{ 
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
