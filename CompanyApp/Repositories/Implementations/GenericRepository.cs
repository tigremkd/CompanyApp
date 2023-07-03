using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        protected GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Create(T entity)
        {
            _context.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool SaveChanges()
        {
            _context.SaveChanges();
            return true;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}
