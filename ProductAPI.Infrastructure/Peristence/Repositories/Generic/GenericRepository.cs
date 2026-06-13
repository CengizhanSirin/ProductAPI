using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Interfaces.Persistence;
using ProductAPI.Domain.Entities;
using ProductAPI.Infrastructure.Peristence.Context;
using System.Linq.Expressions;

namespace ProductAPI.Infrastructure.Peristence.Repositories.Generic
{
    public class GenericRepository<T, TId>(AppDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : notnull
    {
        protected readonly AppDbContext Context = context;

        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => _dbSet.AnyAsync(predicate);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public Task DeleteByIdAsync(TId id) => _dbSet.Where(c => c.Id.Equals(id)).ExecuteDeleteAsync();

        public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            return _dbSet
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public ValueTask<T?> GetByIdAsync(TId id) => _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool tracking = false)
        {
            var query = _dbSet.Where(predicate);
            return tracking ? query : query.AsNoTracking();
        }

    }
}
