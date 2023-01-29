using AutoMapper;
using BookClub.Application.Meetings.Quries;
using BookClub.Application.Meetings.ViewModels;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Presentations.ViewModels;
using ICSSoft.STORMNET.Business.LINQProvider;
using System.Linq;

namespace BookClub.Application.Presentations.Queries
{
    public class GettPresentationListQueryHandler : IRequestHandler<GetPresentationListQuery, PresentationListVm>
    {
        private readonly IMapper _mapper;
        public GettPresentationListQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PresentationListVm> Handle(GetPresentationListQuery request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var presentations = ds.Query<Presentation>(Presentation.Views.PresentationE);
            var meetings = ds.Query<Meeting>(Meeting.Views.MeetingL);

            IList<PresentationDetailsVm> presentionDetailsVms = new List<PresentationDetailsVm>();
            foreach (var item in presentations)
            {
                var presentationInMeeting = from m in meetings
                                            where m.Presentation.Cast<Presentation>()
                                                    .Any(p => p.Id == item.Id)
                                            select m;

                item.Meeting = presentationInMeeting.First();

                PresentationDetailsVm presentationNew = _mapper.Map<PresentationDetailsVm>(item);
                presentionDetailsVms.Add(presentationNew);
            }

            return new PresentationListVm { Presentations = presentionDetailsVms };
        }
    }
}
