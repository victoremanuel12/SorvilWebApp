using BookStore.Context;
using BookStore.Models;
using BookStore.Repository.Interfaces;

namespace BookStore.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
