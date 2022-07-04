﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddASync(T entity); 
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity); 
        Task RemoveAsync(T entity); //savechangeasync() ile kullanacağım için task dönüş tipinde ve async oldular.
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}