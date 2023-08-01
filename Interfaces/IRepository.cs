using System.Linq.Expressions;

namespace BookStore.Interfaces
{
    public interface IOrderRepository<T,Y>
    {
        Task<List<T>> FindWithFilters(Expression<Func<T, bool>> expression, Y filter, DateTimeOffset date);

        Task Create(T entity);

        Task<T> GetFullInfo(Expression<Func<T, bool>> expression, int id);
    }
}