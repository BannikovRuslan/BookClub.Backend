using AutoMapper;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Queries
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailsQueryHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookDetailsVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Books
            //    .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);
            //if(entity == null)
            //{
            //    throw new Common.Exceptions.NotFound(nameof(Book), request.Id);
            //}

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var book = ds.Query<Book>(Book.Views.BookL).First(book => book.Id == request.Id);

            return _mapper.Map<BookDetailsVm>(book);
        }
    }
}
