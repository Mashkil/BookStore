using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset OrderCreationDate { get; set; }

        public int OrderNumber { get; set; }

        public List<BooksInOrder> BooksInOrder { get; set; }
    }
}
