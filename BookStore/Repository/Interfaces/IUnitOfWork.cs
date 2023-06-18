namespace BookStore.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserBookRepository UserBookRepository { get; }
        Task Commit();
    }
}
