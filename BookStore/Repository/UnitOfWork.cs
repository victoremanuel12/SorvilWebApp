using BookStore.Context;
using BookStore.Repository.Interfaces;

namespace BookStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _userRepository;
        protected AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
