using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public double Cost { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
