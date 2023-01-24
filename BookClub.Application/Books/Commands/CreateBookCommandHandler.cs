using AutoMapper;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Commands
{
    // Обрботчик комманды
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            //await _dbContext.Books.AddAsync(book, cancellationToken);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            try
            {
                ds.UpdateObject(book);
            }
            catch (Exception)
            {

                throw;
            }

            book.Id = Guid.Parse(book.__PrimaryKey.ToString());
            return book;
        }
    }
}
