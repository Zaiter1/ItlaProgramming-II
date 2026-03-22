//using System;
//using System.Collections.Generic;
//using System.Text;
//using LearningApi.Persistence;
//using LearningApi.Domain.Entities;

//namespace LearningApi.Infraestructure.Repositories
//{
//    public class ProductRepository
//    {
//        private readonly ApplicationDataContext _context;
//        public ProductRepository(ApplicationDataContext context)
//        {
//            this._context = context;

//        }

//        //public List<Product> GetAllProducts()
//        //{
//        //    return _context.Products.ToList();

//        //}

//        public Product GetProductId(int id)
//        {
//            return _context.Products.FirstOrDefault(s => s.Id == id);

//        }

//        public void AddProduct(Product product)
//        {
//            _context.Products.Add(product);
//            _context.SaveChanges();

//        }

//        public void UpdateProduct(Product product)
//        {
//            var existingProduct = _context.Products.FirstOrDefault(s => s.Id == product.Id);

//            if (existingProduct != null)
//            {
//                existingProduct.ProductName = product.ProductName;
//                existingProduct.Price = product.Price;
//                existingProduct.Stock = product.Stock;
//                existingProduct.DateReceived = product.DateReceived;
//                _context.SaveChanges();
//            }
//        }

//        public void DeleteProduct(int id)
//        {
//            var product = _context.Products.FirstOrDefault(s => s.Id == id);
//            if (product != null)
//            {
//                _context.Products.Remove(product);
//                _context.SaveChanges();
//            }
//        }
//    }
//}

//using Learning.Domain.Repository;
using LearningApi.Domain.Entities;
using LearningApi.Infraestructure.Interfaces;
using LearningApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LearningApi.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDataContext _context;

        public ProductRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}