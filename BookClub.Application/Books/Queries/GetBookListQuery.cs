using BookClub.Application.Books.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Books.Queries
{
    public class GetBookListQuery : IRequest<BookListVm>
    {
        public Guid Id { get; set; }
        public string[] Tags { get; set; }
        public string SearchText { get; set; }
        public string Tag { get; set; }
    }
}
