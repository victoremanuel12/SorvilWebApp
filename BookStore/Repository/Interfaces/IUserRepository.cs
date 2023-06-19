using BookStore.Models;

namespace BookStore.Repository.Interfaces
{
    public interface IUserRepository :  IRepository<User>
    {
        public User GetUserBooks(int id);

    }
}
