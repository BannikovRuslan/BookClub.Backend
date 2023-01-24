using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;

namespace BookClub.Application.Speakers.Commands
{
    public class DeleteSpeakerCommandHandler : IRequestHandler<DeleteSpeakerCommand, SpeakerIdVm>
    {
        private readonly ISpeakersDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteSpeakerCommandHandler(ISpeakersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Unit - тип означающий пустой ответ
        public async Task<SpeakerIdVm> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Speakers.FindAsync(new object[] { request.Id }, cancellationToken);

            //if (entity == null)
            //{
            //    throw new NotFound(nameof(Speaker), request.Id);
            //}

            //_dbContext.Speakers.Remove(entity);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var entity = new Speaker();
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
            

            return _mapper.Map<SpeakerIdVm>(entity);
        }
    }
}
