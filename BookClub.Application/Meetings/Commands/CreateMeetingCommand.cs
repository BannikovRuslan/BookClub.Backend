using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Meetings.ViewModels;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Meetings.Commands
{
    public class CreateMeetingCommand : IRequest<Meeting>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MeetingDetailsVm, Meeting>()
                .ForMember(meeting => meeting.Id, opt => opt.MapFrom(meetingVm => meetingVm.Id))
                .ForMember(meeting => meeting.Date, opt => opt.MapFrom(meetingVm => meetingVm.Date));
        }
    }
}
