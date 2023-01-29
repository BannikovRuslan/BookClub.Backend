using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;

namespace BookClub.Application.Presentations.ViewModels
{
    public class PresentationDetailsVm : IMapWith<Presentation>
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
            profile.CreateMap<Presentation, PresentationDetailsVm>()
                .ForMember(pVm => pVm.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(pVm => pVm.Date, opt => opt.MapFrom(p => p.Date))
                .ForMember(pVm => pVm.Rating, opt => opt.MapFrom(p => p.Rating))
                .ForMember(pVm => pVm.UrlPresentation, opt => opt.MapFrom(p => p.UrlPresentation == null ? "" : p.UrlPresentation))
                .ForMember(pVm => pVm.UrlVideo, opt => opt.MapFrom(p => p.UrlVideo == null ? "" : p.UrlVideo))
                .ForMember(pVm => pVm.Review, opt => opt.MapFrom(p => p.Review == null ? "" : p.Review))
                .ForMember(pVm => pVm.BookId, opt => opt.MapFrom(p => p.Book.Id))
                .ForMember(pVm => pVm.SpeakerId, opt => opt.MapFrom(p => p.Speaker.Id))
                .ForMember(pVm => pVm.MeetingId, opt => opt.MapFrom(p => p.Meeting.Id));
        }
    }
}
