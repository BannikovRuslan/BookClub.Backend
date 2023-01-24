using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.meetings.Commands;
using BookClub.Application.Meetings.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.WebApi.Models
{
    public class UpdateMeetingDto : IMapWith<UpdateMeetingCommand>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMeetingDto, UpdateMeetingCommand>()
                .ForMember(meetingCommand => meetingCommand.Id, opt => opt.MapFrom(meetingDto => meetingDto.Id))
                .ForMember(meetingCommand => meetingCommand.Date, opt => opt.MapFrom(meetingDto => meetingDto.Date));
        }
    }
}
