using AutoMapper;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Unity.Storage.RegistrationSet;

namespace BookClub.Application.Books.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDetailsVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateBookCommandHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BookDetailsVm> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);
            //if (entity == null) {
            //    throw new NotFound(nameof(Book), request.Id);
            //}

            //entity.Cover = request.Cover;
            //entity.Title = request.Title;
            //entity.Author = request.Author;
            //entity.Pages = request.Pages;

            //entity.Tags = new string[request.Tags.Length];
            ////Array.Copy(request.Tags, entity.Tags, request.Tags.Length);

            //entity.Rating= request.Rating;
            //entity.Description = request.Description;

            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var bookUpdate = _mapper.Map<Book>(request);
            var entity = new Book();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                entity.Author = bookUpdate.Author;
                entity.Title = bookUpdate.Title;
                entity.Pages = bookUpdate.Pages;
                entity.Cover = bookUpdate.Cover;
                entity.Tags = bookUpdate.Tags;
                entity.Description = bookUpdate.Description;
                entity.Rating = bookUpdate.Rating;
                ds.UpdateObject(entity);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<BookDetailsVm>(entity);
        }

    }
}
