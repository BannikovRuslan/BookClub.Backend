using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.Commands;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace BookClub.Application.Meetings.Commands
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, Meeting>
    {
        private readonly IMapper _mapper;
        public CreateMeetingCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Meeting> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var meeting = _mapper.Map<Meeting>(request);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            try
            {
                ds.UpdateObject(meeting);
            }
            catch (Exception)
            {

                throw;
            }

            meeting.Id = Guid.Parse(meeting.__PrimaryKey.ToString());
            return meeting;
        }
    }
}
