namespace BookStore.Data.Models
{
    public class BookModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public double Cost { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
