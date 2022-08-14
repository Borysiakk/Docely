using Docely.Domain.Entities;


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
