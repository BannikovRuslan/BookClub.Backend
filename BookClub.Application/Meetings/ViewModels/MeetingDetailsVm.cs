using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;

namespace BookClub.Application.Meetings.ViewModels
{
    public class MeetingDetailsVm : IMapWith<Meeting>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meeting, MeetingDetailsVm>()
                .ForMember(meetingVm => meetingVm.Id, opt => opt.MapFrom(meeting => meeting.Id))
                .ForMember(meetingVm => meetingVm.Date, opt => opt.MapFrom(meeting => meeting.Date));
        }
    }
}
