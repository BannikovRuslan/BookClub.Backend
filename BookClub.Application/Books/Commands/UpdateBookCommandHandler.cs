using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public UpdateBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entiry = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);
            if (entiry == null) {
                throw new NotFound(nameof(Book), request.Id);
            }

            entiry.Cover = request.Cover;
            entiry.Title = request.Title;
            entiry.Author = request.Author;
            entiry.Pages = request.Pages;
            //entiry.Tags = request.Tags;
            entiry.Rating= request.Rating;
            entiry.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
