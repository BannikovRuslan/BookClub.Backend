using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Presentations.ViewModels;

namespace BookClub.Application.Presentations.Commands
{
    public class DeletePresentationCommandHandler : IRequestHandler<DeletePresentationCommand, PresentationIdVm>
    {
        private readonly IMapper _mapper;
        public DeletePresentationCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PresentationIdVm> Handle(DeletePresentationCommand request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var entity = new Presentation();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                entity.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(entity);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<PresentationIdVm>(entity);
        }
    }
}
