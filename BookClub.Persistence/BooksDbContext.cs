using BookClub.Application.Interfaces;
using BookClub.Domains;
using BookClub.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Persistence
{
    public class BooksDbContext : DbContext, IBooksDbContext
    {
        public DbSet<Book> Books { get; set; }
        
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
