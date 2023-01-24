using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Speakers.Commands;

namespace BookClub.WebApi.Models
{
    public class CreateSpeakerDto : IMapWith<CreateSpeakerCommand>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSpeakerDto, CreateSpeakerCommand>()
                .ForMember(speakerCommand => speakerCommand.FirstName, opt => opt.MapFrom(speakerDto => speakerDto.FirstName))
                .ForMember(speakerCommand => speakerCommand.LastName, opt => opt.MapFrom(speakerDto => speakerDto.LastName))
                .ForMember(speakerCommand => speakerCommand.MiddleName, opt => opt.MapFrom(speakerDto => speakerDto.MiddleName))
                .ForMember(speakerCommand => speakerCommand.Foto, opt => opt.MapFrom(speakerDto => speakerDto.Foto));
        }
    }
}
