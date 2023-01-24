using AutoMapper;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using BookClub.Application.Speakers.ViewModels;
using Microsoft.EntityFrameworkCore;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business.LINQProvider;
using System.Linq;

namespace BookClub.Application.Speakers.Queries
{
    public class GetSpeakerDetailsQueryHandler : IRequestHandler<GetSpeakerDetailsQuery, SpeakerDetailsVm>
    {
        private readonly ISpeakersDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSpeakerDetailsQueryHandler(ISpeakersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SpeakerDetailsVm> Handle(GetSpeakerDetailsQuery request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Speakers
            //    .FirstOrDefaultAsync(speaker => speaker.Id == request.Id, cancellationToken);

            //if (entity == null)
            //{
            //    throw new Common.Exceptions.NotFound(nameof(Speaker), request.Id);
            //}

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var speakers = ds.Query<Speaker>(Speaker.Views.SpeakerL);
            var entity = speakers.First(speaker => speaker.Id == request.Id);

            return _mapper.Map<SpeakerDetailsVm>(entity);
        }
    }

}
