using System;
using System.Collections.Generic;
using System.Text;
using LearningApi.Persistence;
using LearningApi.Domain.Entities;

namespace LearningApi.Infraestructure.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDataContext _context;
        public GenericRepository(ApplicationDataContext context)
        {
            this._context = context;

        }

        public List<TEntity> GetAll() 
        {
            return _context.Set<TEntity>().ToList();

        }

        public TEntity GetById(int id ) 
        {
            return _context.Set<TEntity>().Find(id);

        }

        public void Add(TEntity entity) 
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        
        }

        public void Update(TEntity entity) 
        {
          _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) 
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }

}
