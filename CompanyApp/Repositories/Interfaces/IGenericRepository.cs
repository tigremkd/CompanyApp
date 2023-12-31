﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T Get(int id);
        bool SaveChanges();
    }
}
