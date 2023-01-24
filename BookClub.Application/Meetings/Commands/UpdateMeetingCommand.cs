using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Meetings.ViewModels;
using BookClub.Domains;
using MediatR;
using System;

namespace BookClub.Application.Meetings.Commands
{
    public class UpdateMeetingCommand : IRequest<MeetingDetailsVm>, IMapWith<Meeting>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMeetingCommand, Meeting>()
                .ForMember(meeting => meeting.Id, opt => opt.MapFrom(meetingVm => meetingVm.Id))
                .ForMember(meeting => meeting.Date, opt => opt.MapFrom(meetingVm => meetingVm.Date));
        }
    }
}
