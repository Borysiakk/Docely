using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<T?> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
