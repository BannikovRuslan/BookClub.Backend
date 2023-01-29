using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Common.Mappings.CustomConverters;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Domains;
using MediatR;
using System;

namespace BookClub.Application.Presentations.Commands
{
    public class UpdatePresentationCommand : IRequest<PresentationDetailsVm>, IMapWith<Presentation>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string UrlPresentation { get; set; }
        public string UrlVideo { get; set; }
        public string Review { get; set; }
        public Guid BookId { get; set; }
        public Guid SpeakerId { get; set; }
        public Guid MeetingId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePresentationCommand, Presentation>()
                .ForMember(presentation => presentation.Id, opt => opt.MapFrom(pCommand => pCommand.Id))
                .ForMember(presentation => presentation.Date, opt => opt.MapFrom(pCommand => pCommand.Date))
                .ForMember(presentation => presentation.Rating, opt => opt.MapFrom(pCommand => pCommand.Rating))
                .ForMember(presentation => presentation.UrlPresentation, opt => opt.MapFrom(pCommand => pCommand.UrlPresentation))
                .ForMember(presentation => presentation.UrlVideo, opt => opt.MapFrom(pCommand => pCommand.UrlVideo))
                .ForMember(presentation => presentation.Review, opt => opt.MapFrom(pCommand => pCommand.Review))
                .ForMember(presentation => presentation.Book, opt => opt.ConvertUsing(new IdToBookConverter(), "BookId"))
                .ForMember(presentation => presentation.Speaker, opt => opt.ConvertUsing(new IdToSpeakerConverter(), "SpeakerId"))
                .ForMember(presentation => presentation.Meeting, opt => opt.ConvertUsing(new IdToMeetingConverter(), "MeetingId"));
        }
    }
}
