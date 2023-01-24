using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Meetings.Commands;

namespace BookClub.WebApi.Models
{
    public class CreateMeetingDto : IMapWith<CreateMeetingCommand>
    {
        public string Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMeetingDto, CreateMeetingCommand>()
                .ForMember(meetingCommand => meetingCommand.Date, opt => opt.MapFrom(meetingDto => meetingDto.Date));
        }
    }
}
