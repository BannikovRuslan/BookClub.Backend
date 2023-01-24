using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var booksSearchText = await _dbContext.Books
            //    .Where(book => book.Author.Contains(request.SearchText)
            //                        || book.Title.Contains(request.SearchText)
            //                        || book.Description.Contains(request.SearchText))
            //    .ProjectTo<BookDetailsVm>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);
            //var booksTags = await _dbContext.Books
            //    .ProjectTo<BookDetailsVm>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);
            //if (request.SearchText.Length > 0)
            //{
            //    booksTags = booksTags
            //        .Where(book => book.Tags.Any(b => b.Contains(request.SearchText)))
            //        .ToList();
            //}
            //if (booksSearchText.Count > 0)
            //{
            //    booksTags = booksSearchText.Union(booksTags).Distinct(new BookComparer()).ToList();
            //}
            //if (request.Tag.Length>0)
            //{
            //    booksTags = booksTags
            //        .Where(book => book.Tags.Any(b => b.Contains(request.Tag)))
            //        .ToList();
            //}

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var books = ds.Query<Book>(Book.Views.BookL);
            var booksSearchText = books.Where(book => (book.Title.Contains(request.SearchText)
                                                || book.Author.Contains(request.SearchText)
                                                || book.Tags.Contains(request.SearchText)
                                                || book.Description.Contains(request.SearchText))
                                                && book.Tags.Contains(request.Tag)).ToList();

            IList<BookDetailsVm> bookDetailsVms = new List<BookDetailsVm>();
            foreach (var item in booksSearchText)
            {
                BookDetailsVm bookNew = _mapper.Map<BookDetailsVm>(item);
                bookDetailsVms.Add(bookNew);
            }

            return new BookListVm { Books =  bookDetailsVms };
        }
    }

    class BookComparer : IEqualityComparer<BookDetailsVm>
    {
        public bool Equals(BookDetailsVm x, BookDetailsVm y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(BookDetailsVm book)
        {
            if (Object.ReferenceEquals(book, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashBookId = book.Id.GetHashCode();
            return hashBookId;
        }
    }
}
