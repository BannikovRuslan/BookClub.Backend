using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Presentations.ViewModels;
using ICSSoft.STORMNET.Business.LINQProvider;
using System.Linq;
using ICSSoft.STORMNET;

namespace BookClub.Application.Presentations.Queries
{
    public class GetPresentationDetailsQueryHandler : IRequestHandler<GetPresentationDetailsQuery, PresentationDetailsVm>
    {
        private readonly IMapper _mapper;
        public GetPresentationDetailsQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PresentationDetailsVm> Handle(GetPresentationDetailsQuery request, CancellationToken cancellationToken)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            //var pdSpeaker = new PseudoDetail<Speaker, Presentation>(Presentation.Views.PresentationE,
            //    Information.ExtractPropertyPath<Presentation>(p => p.Speaker));
            //var speakers = ds.Query<Speaker>(Speaker.Views.SpeakerL);
            //var spekerInPresentation = from s in speakers where pdSpeaker.Any() select s;
            
            var presentation = ds.Query<Presentation>(Presentation.Views.PresentationE)
                .First(presentation => presentation.Id == request.Id);

            var meeting = ds.Query<Meeting>(Meeting.Views.MeetingL);
            var presentationInMeeting = from m in meeting 
                                        where m.Presentation.Cast<Presentation>()
                                                .Any(p => p.Id == request.Id) select m;

            presentation.Meeting = presentationInMeeting.First();

            return _mapper.Map<PresentationDetailsVm>(presentation);
        }
    }
}
