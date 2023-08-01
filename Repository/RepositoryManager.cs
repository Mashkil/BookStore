using BookStore.Data;
using BookStore.Interfaces;

namespace BookStore.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BookStoreContext _dbContext;
        private IBookRepository _bookRepository;
        private IOrderRepository _orderRepository;

        public RepositoryManager(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IBookRepository Book
        {
            get
            {
                _bookRepository ??= new BookRepository(_dbContext);
                return _bookRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                _orderRepository ??= new OrderRepository(_dbContext);
                return _orderRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
