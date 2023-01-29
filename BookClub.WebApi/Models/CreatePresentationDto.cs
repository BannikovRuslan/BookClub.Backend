using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Presentations.Commands;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Domains;
using System;

namespace BookClub.WebApi.Models
{
    public class CreatePresentationDto : IMapWith<CreatePresentationCommand>
    {
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
            profile.CreateMap<CreatePresentationDto, CreatePresentationCommand>()
                .ForMember(pCommand => pCommand.Date, opt => opt.MapFrom(pDto => pDto.Date))
                .ForMember(pCommand => pCommand.Rating, opt => opt.MapFrom(pDto => pDto.Rating))
                .ForMember(pCommand => pCommand.UrlPresentation, opt => opt.MapFrom(pDto => pDto.UrlPresentation))
                .ForMember(pCommand => pCommand.UrlVideo, opt => opt.MapFrom(pDto => pDto.UrlVideo))
                .ForMember(pCommand => pCommand.Review, opt => opt.MapFrom(pDto => pDto.Review))
                .ForMember(pCommand => pCommand.BookId, opt => opt.MapFrom(pDto => pDto.BookId))
                .ForMember(pCommand => pCommand.SpeakerId, opt => opt.MapFrom(pDto => pDto.SpeakerId))
                .ForMember(pCommand => pCommand.MeetingId, opt => opt.MapFrom(pDto => pDto.MeetingId));
        }
    }
}
