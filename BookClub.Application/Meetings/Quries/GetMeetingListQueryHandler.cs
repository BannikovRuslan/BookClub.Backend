using AutoMapper;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.Queries;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Meetings.ViewModels;
using ICSSoft.STORMNET.Business.LINQProvider;
using System.Linq;

namespace BookClub.Application.Meetings.Quries
{
    public class GetMeetingListQueryHandler : IRequestHandler<GetMeetingListQuery, MeetingListVm>
    {
        private readonly IMapper _mapper;
        public GetMeetingListQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MeetingListVm> Handle(GetMeetingListQuery request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var meetings = ds.Query<Meeting>(Meeting.Views.MeetingL);
            var meetingsDate = meetings.Where(meeting => meeting.Date == request.SearchDate);

            IList<MeetingDetailsVm> meetingDetailsVms = new List<MeetingDetailsVm>();
            foreach (var item in meetingsDate)
            {
                MeetingDetailsVm meetingNew = new MeetingDetailsVm()
                {
                    Id = item.Id,
                    Date = item.Date
                };
                meetingDetailsVms.Add(meetingNew);
            }

            return new MeetingListVm { Meetings = meetingDetailsVms };
        }
    }
}
