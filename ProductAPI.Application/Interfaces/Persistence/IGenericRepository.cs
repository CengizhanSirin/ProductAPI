using System.Linq.Expressions;

namespace ProductAPI.Application.Interfaces.Persistence
{
    public interface IGenericRepository<T, TId> where T : class where TId : notnull
    { 

        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool tracking = false);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        ValueTask<T?> GetByIdAsync(TId id);

        ValueTask AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task DeleteByIdAsync(TId id);
    }
}
