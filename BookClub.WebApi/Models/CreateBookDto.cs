using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.Queries;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
//using BookClub.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
                .ConvertUsing(new FullConverter());
            //.ForMember(bookCommand => bookCommand.Cover, opt => opt.MapFrom(bookDto => bookDto.Cover))
            //.ForMember(bookCommand => bookCommand.Title, opt => opt.MapFrom(bookDto => bookDto.Title))
            //.ForMember(bookCommand => bookCommand.Author, opt => opt.MapFrom(bookDto => bookDto.Author))
            //.ForMember(bookCommand => bookCommand.Pages, opt => opt.MapFrom(bookDto => bookDto.Pages))
            ////.ForMember(bookItem => bookItem.Tags, opt => opt.Ignore()) 
            //.ForMember(bookCommand => bookCommand.Tags, opt => opt.ConvertUsing<ArrayStringConverter, string[]>())
            //.ForMember(bookCommand => bookCommand.Rating, opt => opt.MapFrom(bookDto => bookDto.Rating))
            //.ForMember(bookCommand => bookCommand.Description, opt => opt.MapFrom(bookDto => bookDto.Description));  

        }
    }

    public class FullConverter : ITypeConverter<CreateBookDto, CreateBookCommand>
    {
        public CreateBookCommand Convert(CreateBookDto bookDto, CreateBookCommand bookCommand, ResolutionContext context)
        {
            bookCommand = new CreateBookCommand
            {
                Cover = bookDto.Cover,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Pages = bookDto.Pages,
                Tags = new string[bookDto.Tags.Length],
                Rating = bookDto.Rating,
                Description = bookDto.Description
            };

            Array.Copy(bookDto.Tags, bookCommand.Tags, bookDto.Tags.Length);

            return bookCommand;
        }
    }

    public class ArrayStringConverter : IValueConverter<string[], string[]>
    {
        public string[] Convert(string[] Tags, ResolutionContext context)
        {
            string[] TagsCopy = new string[Tags.Length];

            Array.Copy(Tags, TagsCopy, Tags.Length);
            return TagsCopy;
        }
    }
}

