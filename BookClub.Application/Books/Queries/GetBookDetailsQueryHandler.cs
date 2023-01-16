using AutoMapper;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            var entity = await _dbContext.Books
                .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new Common.Exceptions.NotFound(nameof(Book), request.Id);
            }

            return _mapper.Map<BookDetailsVm>(entity);
        }
    }
}
