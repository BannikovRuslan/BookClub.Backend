using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Speakers.Commands
{
    public class UpdateSpeakerCommand : IRequest<SpeakerDetailsVm>, IMapWith<Speaker>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSpeakerCommand, Speaker>()
                //.ForMember(speaker => speaker.__PrimaryKey, opt => opt.MapFrom(speakerCommand => speakerCommand.Id))
                .ForMember(speaker => speaker.FirstName, opt => opt.MapFrom(speakerCommand => speakerCommand.FirstName))
                .ForMember(speaker => speaker.LastName, opt => opt.MapFrom(speakerCommand => speakerCommand.LastName))
                .ForMember(speaker => speaker.MiddleName, opt => opt.MapFrom(speakerCommand => speakerCommand.MiddleName))
                .ForMember(speaker => speaker.Foto, opt => opt.MapFrom(speakerCommand => speakerCommand.Foto));
        }
    }
}
