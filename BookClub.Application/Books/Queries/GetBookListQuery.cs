using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Books.Queries
{
    public class GetBookListQuery : IRequest<BookListVm>
    {
        public int Id { get; set; }
        public string Author { get; set; }
    }
}
