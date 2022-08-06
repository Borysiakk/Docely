using Docely.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(long id);
        Task AddAsync(T entities);
        void Update(T entities);
        Task SaveAsync();

    }
}
