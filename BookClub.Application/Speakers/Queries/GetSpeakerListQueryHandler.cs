using AutoMapper;
using BookClub.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using BookClub.Application.Speakers.ViewModels;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;

namespace BookClub.Application.Speakers.Queries
{
    public class GetSpeakerListQueryHandler : IRequestHandler<GetSpeakerListQuery, SpeakerListVm>
    {
        private readonly ISpeakersDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSpeakerListQueryHandler(ISpeakersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SpeakerListVm> Handle(GetSpeakerListQuery request, CancellationToken cancellationToken)
        {
            //var speakersSearchText = await _dbContext.Speakers
            //    .Where(speaker => speaker.FirstName.Contains(request.SearchText)
            //                        || speaker.LastName.Contains(request.SearchText)
            //                        || speaker.MiddleName.Contains(request.SearchText))
            //    .ProjectTo<SpeakerDetailsVm>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var speakers = ds.Query<Speaker>(Speaker.Views.SpeakerL);
            var speakersSearchText = speakers
                                        .Where(speaker => speaker.FirstName.Contains(request.SearchText)
                                                || speaker.LastName.Contains(request.SearchText)
                                                || speaker.MiddleName.Contains(request.SearchText));

            IList<SpeakerDetailsVm> speakerDetailsVms = new List<SpeakerDetailsVm>();
            foreach (var item in speakersSearchText)
            {
                SpeakerDetailsVm speakerNew = new SpeakerDetailsVm()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    Foto = item.Foto,
                    Id = item.Id,
                };
                speakerDetailsVms.Add(speakerNew);
            }

            return new SpeakerListVm { Speakers = speakerDetailsVms };
        }
    }
}
