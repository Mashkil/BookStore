using BookStore.Data.Entities;
using BookStore.Data.Models;

namespace BookStore.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OutputOrder>> FindWithFilters(int orderId, DateTime date);

        Task<int> CreateOrder(int orderNumber);

        Task AddBookInOrder(int orderId, int bookId);
    }
}
