﻿using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }


    }
}
