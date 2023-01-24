using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Interfaces;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Meetings.ViewModels;

namespace BookClub.Application.Meetings.Commands
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand, MeetingDetailsVm>
    {
        private readonly IMapper _mapper;
        public UpdateMeetingCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<MeetingDetailsVm> Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
        {

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var meetingUpdate = _mapper.Map<Meeting>(request);
            var entity = new Meeting();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                entity.Date = meetingUpdate.Date;
                ds.UpdateObject(entity);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<MeetingDetailsVm>(entity);
        }
    }
}
