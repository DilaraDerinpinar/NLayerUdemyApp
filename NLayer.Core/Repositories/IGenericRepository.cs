using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddASync(T entity); //var olan threadlari bloklamamak için async kullanılır bu işlem.
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity); //update ve remove un ef tarafında async tarafı yok çünkü kısa işlemler ancak addin var.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
