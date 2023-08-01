using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Interfaces;

namespace BookStore.Repository
{
    public class BookRepository : RepositoryBase<Book, string>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context) { }

        public async Task CreateBook(Book book) => await Create(book);

        public async Task<List<Book>> FindWithFilters(string title, DateTimeOffset date)
        {
            return await FindWithFilters(e => e.Title == title && e.Created.Year == date.Year, title, date);
        }

        public async Task<Book> GetFullInfo(int id)
        {
            return await base.GetFullInfo(e => e.Id == id, id);
        }
    }
}
