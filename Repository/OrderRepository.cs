using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Data.Models;
using BookStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class OrderRepository : RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(BookStoreContext context) : base(context) { }

        public async Task AddBookInOrder(int orderId, int bookId)
        {
            _dbContext.BooksInOrders.Add(new BooksInOrder
            {
                BookId = bookId,
                OrderId = orderId
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateOrder(int orderNumber)
        {
            var order = new Order
            {
                OrderNumber = orderNumber,
                OrderCreationDate = DateTimeOffset.Now
            };

            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OutputOrder>> FindWithFilters(int orderId, DateTime date)
        {
            return await _dbContext.Orders
                 .Include(e => e.BooksInOrder)
                 .ThenInclude(e=>e.Book)
                 .Where(order => order.Id == orderId && order.OrderCreationDate.Date == date)
                 .Select(x=> new OutputOrder
                 {
                     OrderCreationDate = x.OrderCreationDate,
                     OrderNumber = x.OrderNumber,
                     Books = x.BooksInOrder.Select(x=>x.Book).ToList()
                 })
                 .ToListAsync();
        }
    }
}
