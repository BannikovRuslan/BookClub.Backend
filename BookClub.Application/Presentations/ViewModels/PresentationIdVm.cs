using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;


namespace BookClub.Application.Presentations.ViewModels
{
    public class PresentationIdVm : IMapWith<Presentation>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Presentation, PresentationIdVm>()
                .ForMember(presentationVm => presentationVm.Id, opt => opt.MapFrom(presentation => presentation.Id));
        }
    }
}
