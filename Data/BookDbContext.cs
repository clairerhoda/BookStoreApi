using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
	public class BookDbContext : DbContext
	{
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        // representation of the table in the databse
        // It will allows us to manage data from the table Product
        public DbSet<Book> Books { get; set; }
    }
}

