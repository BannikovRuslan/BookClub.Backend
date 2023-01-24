using AutoMapper;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Unity.Storage.RegistrationSet;

namespace BookClub.Application.Books.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookIdVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteBookCommandHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Unit - тип означающий пустой ответ
        public async Task<BookIdVm> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Books.FindAsync(new object[] { request.Id }, cancellationToken);
            //if (entity == null)
            //{
            //    throw new NotFound(nameof(Book), request.Id);
            //}
            //_dbContext.Books.Remove(entity);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var entity = new Book();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                entity.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(entity);
            }
            catch (System.Exception)
            {

                throw;
            }

            return _mapper.Map<BookIdVm>(entity);
        }
    }
}
