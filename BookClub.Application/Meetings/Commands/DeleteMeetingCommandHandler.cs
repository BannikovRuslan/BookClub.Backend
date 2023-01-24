using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Meetings.ViewModels;

namespace BookClub.Application.Meetings.Commands
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand, MeetingIdVm>
    {
        private readonly IMapper _mapper;
        public DeleteMeetingCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MeetingIdVm> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var entity = new Meeting();
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

            return _mapper.Map<MeetingIdVm>(entity);
        }
    }
}
