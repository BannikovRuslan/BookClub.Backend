using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Books.Queries
{
    public class BookListVm
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
