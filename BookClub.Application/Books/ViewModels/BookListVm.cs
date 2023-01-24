using System.Collections.Generic;

namespace BookClub.Application.Books.ViewModels
{
    public class BookListVm
    {
        public IList<BookDetailsVm> Books { get; set; }
    }
}
