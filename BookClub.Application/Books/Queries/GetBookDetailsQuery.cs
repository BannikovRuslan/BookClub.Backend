using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Books.Queries
{
    public class GetBookDetailsQuery : IRequest<BookDetailsVm>
    {
        public int Id { get; set; }
    }
}
