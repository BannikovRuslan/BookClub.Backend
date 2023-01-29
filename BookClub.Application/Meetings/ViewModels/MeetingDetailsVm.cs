using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Common.Mappings.CustomConverters;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Domains;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookClub.Application.Meetings.ViewModels
{
    public class MeetingDetailsVm : IMapWith<Meeting>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<PresentationDetailsVm> Presentations { get; set; }        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meeting, MeetingDetailsVm>()
                .ForMember(meetingVm => meetingVm.Id, opt => opt.MapFrom(meeting => meeting.Id))
                .ForMember(meetingVm => meetingVm.Date, opt => opt.MapFrom(meeting => meeting.Date))
                .ForMember(meetingVm => meetingVm.Presentations, opt => opt.ConvertUsing(new PresentationToPresentationDetailsVm(), "Presentation"));
        }
    }


}
