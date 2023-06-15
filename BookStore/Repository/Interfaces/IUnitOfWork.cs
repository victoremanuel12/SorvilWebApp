namespace BookStore.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
