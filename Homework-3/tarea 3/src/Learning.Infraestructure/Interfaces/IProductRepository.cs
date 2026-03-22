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

//using LearningApi.Domain.Repository;
//using LearningApi.Domain.Entities;
//using LearningApi.Persistence;
//using Microsoft.EntityFrameworkCore;

//namespace LearningApi.Infraestructure.Repositories
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly ApplicationDataContext _context;

//        public ProductRepository(ApplicationDataContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Product>> GetAll()
//        {
//            return await _context.Products.ToListAsync();
//        }

//        public async Task<Product?> GetById(int id)
//        {
//            return await _context.Products.FindAsync(id);
//        }

//        public async Task<Product> Create(Product product)
//        {
//            _context.Products.Add(product);
//            await _context.SaveChangesAsync();
//            return product;
//        }

//        public async Task Update(Product product)
//        {
//            _context.Products.Update(product);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Delete(Product product)
//        {
//            _context.Products.Remove(product);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
