using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BooksDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
