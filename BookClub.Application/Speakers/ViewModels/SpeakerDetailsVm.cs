using AutoMapper;
using BookClub.Domains;
using BookClub.Application.Common.Mappings;
using System;

namespace BookClub.Application.Speakers.ViewModels
{
    public class SpeakerDetailsVm : IMapWith<Speaker>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Speaker, SpeakerDetailsVm>()
                .ForMember(speakerVm => speakerVm.Id, opt => opt.MapFrom(speaker => speaker.Id))
                .ForMember(speakerVm => speakerVm.FirstName, opt => opt.MapFrom(speaker => speaker.FirstName == null ? "" : speaker.FirstName))
                .ForMember(speakerVm => speakerVm.LastName, opt => opt.MapFrom(speaker => speaker.LastName == null ? "" : speaker.LastName))
                .ForMember(speakerVm => speakerVm.MiddleName, opt => opt.MapFrom(speaker => speaker.MiddleName == null ? "" : speaker.MiddleName))
                .ForMember(speakerVm => speakerVm.Foto, opt => opt.MapFrom(speaker => speaker.Foto == null ? "" : speaker.Foto));
        }
    }
}
