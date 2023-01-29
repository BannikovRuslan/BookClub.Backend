using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Meetings.ViewModels;
using ICSSoft.STORMNET.Business.LINQProvider;
using System.Linq;

namespace BookClub.Application.Meetings.Quries
{
    public class GetMeetingDetailsQueryHandler : IRequestHandler<GetMeetingDetailsQuery, MeetingDetailsVm>
    {
        private readonly IMapper _mapper;
        public GetMeetingDetailsQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MeetingDetailsVm> Handle(GetMeetingDetailsQuery request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var meeting = ds.Query<Meeting>(Meeting.Views.MeetingL).First(meeting => meeting.Id == request.Id);

            return _mapper.Map<MeetingDetailsVm>(meeting);
        }
    }
}
