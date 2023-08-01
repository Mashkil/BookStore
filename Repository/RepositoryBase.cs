using BookStore.Data;
using BookStore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Repository
{
    public class RepositoryBase<T, Y> : IOrderRepository<T, Y> where T : class
    {
        protected BookStoreContext _dbContext;

        public RepositoryBase(BookStoreContext context)
        {
            _dbContext = context;
        }

        public async Task Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindWithFilters(Expression<Func<T, bool>> expression, Y filter, DateTimeOffset date)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public Task<T> GetFullInfo(Expression<Func<T, bool>> expression, int id)
        {
            return _dbContext.Set<T>().FirstAsync(expression);
        }
    }
}