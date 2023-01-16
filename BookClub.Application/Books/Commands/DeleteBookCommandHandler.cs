using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public DeleteBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Unit - тип означающий пустой ответ
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entiry = await _dbContext.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entiry != null)
            {
                throw new NotFound(nameof(Book), request.Id);
            }

            _dbContext.Books.Remove(entiry);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
