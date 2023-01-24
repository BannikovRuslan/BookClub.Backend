using BookClub.Application.Interfaces;
using BookClub.Domains;
using BookClub.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Persistence
{
    public class BookClubDbContext : Microsoft.EntityFrameworkCore.DbContext, IBooksDbContext, ISpeakersDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        
        public BookClubDbContext(DbContextOptions<BookClubDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new SpeakerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
