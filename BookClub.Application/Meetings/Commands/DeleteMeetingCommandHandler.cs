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
            var meeting = new Meeting();
            try
            {
                meeting.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(meeting);
                
                var presentation = new Presentation();
                foreach (var item in meeting.Presentation)
                {
                    presentation = item as Presentation;
                    presentation.SetExistObjectPrimaryKey(presentation.Id);
                    ds.LoadObject(presentation);
                    presentation.SetStatus(ObjectStatus.Deleted);
                    ds.UpdateObject(presentation);
                }

                meeting.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(meeting);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<MeetingIdVm>(meeting);
        }
    }
}
