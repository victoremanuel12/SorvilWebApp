using BookStore.Context;
using BookStore.Models;
using BookStore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public User GetUserBooks( int id)
        {
            var userBooks  = _context.Users.Where(x => x.Id == id).Include( b => b.UserBook).SingleOrDefault();
            return userBooks;
        }
    }
}
