using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;

namespace BookClub.Application.Speakers.ViewModels
{
    public class SpeakerIdVm : IMapWith<Speaker>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Speaker, SpeakerIdVm>()
                .ForMember(speakerVm => speakerVm.Id, opt => opt.MapFrom(speaker => speaker.Id));
        }
    }
}
