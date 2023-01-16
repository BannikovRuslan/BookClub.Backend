using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookClub.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Books.Queries
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BookListVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookListQueryHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookListVm> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await _dbContext.Books
                .Where(book => book.Author == request.Author)
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BookListVm { Books = booksQuery };
        }
    }
}
