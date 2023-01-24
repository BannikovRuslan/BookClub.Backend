using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Speakers.Commands;
using System;

namespace BookClub.WebApi.Models
{
    public class UpdateSpeakerDto : IMapWith<UpdateSpeakerCommand>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSpeakerDto, UpdateSpeakerCommand>()
                .ForMember(speakerCommand => speakerCommand.Id, opt => opt.MapFrom(speakerDto => speakerDto.Id))
                .ForMember(speakerCommand => speakerCommand.FirstName, opt => opt.MapFrom(speakerDto => speakerDto.FirstName))
                .ForMember(speakerCommand => speakerCommand.LastName, opt => opt.MapFrom(speakerDto => speakerDto.LastName))
                .ForMember(speakerCommand => speakerCommand.MiddleName, opt => opt.MapFrom(speakerDto => speakerDto.MiddleName))
                .ForMember(speakerCommand => speakerCommand.Foto, opt => opt.MapFrom(speakerDto => speakerDto.Foto));
        }
    }
}
