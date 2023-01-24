using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;

namespace BookClub.Application.Meetings.ViewModels
{
    public class MeetingIdVm : IMapWith<Meeting>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meeting, MeetingIdVm>()
                .ForMember(meetingVm => meetingVm.Id, opt => opt.MapFrom(meeting => meeting.Id));
        }
    }
}
