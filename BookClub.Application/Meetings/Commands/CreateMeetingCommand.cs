using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Meetings.ViewModels;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Meetings.Commands
{
    public class CreateMeetingCommand : IRequest<Meeting>, IMapWith<Meeting>
    {
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMeetingCommand, Meeting>()
                .ForMember(meeting => meeting.Date, opt => opt.MapFrom(meetingVm => meetingVm.Date));
        }
    }
}
