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
using ICSSoft.STORMNET;

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
            LoadingCustomizationStruct lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Meeting), "MeetingL");
            
            int startMeeting = 1;
            int endMeeeting = ds.GetObjectsCount(lcs);

            if (request.page > 0 && request.limit > 0)
            {
                startMeeting = request.limit * request.page - request.limit + 1;
                endMeeeting = request.limit * request.page;
            }

            lcs.RowNumber = new RowNumberDef(startMeeting, endMeeeting);
            //lcs.ColumnsOrder = new[] { new ColumnsSortDef(Information.ExtractPropertyName<Meeting>(m => m.Date), SortOrder.Asc) };

            var meetings = ds.LoadObjects(lcs).Cast<Meeting>(); 
            //meetings = ds.Query<Meeting>(Meeting.Views.MeetingL);
            if (request.SearchDate != null)
            {
                meetings = meetings.Where(meeting => meeting.Date.Date == request.SearchDate.Value.Date);
            }

            List<MeetingDetailsVm> meetingDetailsVms = new List<MeetingDetailsVm>();
            foreach (var item in meetings)
            {
                MeetingDetailsVm meetingNew = _mapper.Map<MeetingDetailsVm>(item);
                meetingDetailsVms.Add(meetingNew);
            }

            return new MeetingListVm { Meetings = meetingDetailsVms };
        }
    }
}
