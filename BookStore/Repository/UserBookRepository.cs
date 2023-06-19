using BookStore.Context;
using BookStore.Models;
using BookStore.Repository.Interfaces;

namespace BookStore.Repository
{
    public class UserBookRepository : Repository<UserBook>,IUserBookRepository
    {
        public UserBookRepository(AppDbContext context) : base(context) 
        {
            
        }
    }
}
