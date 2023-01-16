﻿using MediatR;

namespace BookClub.Application.Books.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
