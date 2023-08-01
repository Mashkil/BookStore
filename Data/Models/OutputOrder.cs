using BookStore.Data.Entities;

namespace BookStore.Data.Models
{
    public class OutputOrder
    {
        public DateTimeOffset OrderCreationDate { get; set; }

        public int OrderNumber { get; set; }

        public List<Book>? Books { get; set; }
    }
}
