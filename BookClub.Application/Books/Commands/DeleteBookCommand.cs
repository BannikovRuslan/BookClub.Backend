using BookClub.Application.Books.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Books.Commands
{
    public class DeleteBookCommand : IRequest<BookIdVm>
    {
        public Guid Id { get; set; }
    }
}
