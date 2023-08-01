using BookStore.Data.Entities;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> FindWithFilters(string title, DateTimeOffset date);

        Task CreateBook(Book book);

        Task<Book> GetFullInfo(int id);
    }
}