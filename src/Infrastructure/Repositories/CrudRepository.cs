using Application.Common;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly IApplicationDbContext _dbContext;

        public CrudRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        
        public async Task<T> AddAsync(T entity)
        {
            var entry = _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
