using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BookClubDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
