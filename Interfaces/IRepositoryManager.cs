namespace BookStore.Interfaces
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }

        IOrderRepository Order { get; }

        Task Save();
    }
}
