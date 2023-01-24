using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Common.Mappings.CustomConverters;


namespace BookClub.WebApi.Models
{
    public class CreateBookDto : IMapWith<CreateBookCommand>
    {
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.Cover, opt => opt.MapFrom(bookDto => bookDto.Cover))
                .ForMember(bookCommand => bookCommand.Title, opt => opt.MapFrom(bookDto => bookDto.Title))
                .ForMember(bookCommand => bookCommand.Author, opt => opt.MapFrom(bookDto => bookDto.Author))
                .ForMember(bookCommand => bookCommand.Pages, opt => opt.MapFrom(bookDto => bookDto.Pages))
                .ForMember(bookCommand => bookCommand.Tags, opt => opt.ConvertUsing(new StringArrayToStringArray()))
                .ForMember(bookCommand => bookCommand.Rating, opt => opt.MapFrom(bookDto => bookDto.Rating))
                .ForMember(bookCommand => bookCommand.Description, opt => opt.MapFrom(bookDto => bookDto.Description));
        }
    }
}

