﻿using BookStore.Models;

namespace BookStore.Repository.Interfaces
{
    public interface IUserRepository :  IRepository<User>
    {
        User GetUserBooks(int id);
    }
}
