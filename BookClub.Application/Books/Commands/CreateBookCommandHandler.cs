using BookClub.Application.Interfaces;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Commands
{
    // Обрботчик комманды
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBooksDbContext _dbContext;
        public CreateBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Cover= request.Cover,
                Title = request.Title,
                Author = request.Author,
                Pages= request.Pages,
                Tags= request.Tags,
                Rating= request.Rating,
                Description= request.Description,
            };

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
