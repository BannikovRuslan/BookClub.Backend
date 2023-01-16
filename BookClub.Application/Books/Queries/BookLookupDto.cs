using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;
using System.Linq;

namespace BookClub.Application.Books.Queries
{
    public class BookLookupDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookItem => bookItem.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookItem => bookItem.Cover, opt => opt.MapFrom(book => book.Cover))
                .ForMember(bookItem => bookItem.Title, opt => opt.MapFrom(book => book.Title))
                .ForMember(bookItem => bookItem.Author, opt => opt.MapFrom(book => book.Author))
                .ForMember(bookItem => bookItem.Pages, opt => opt.MapFrom(book => book.Pages))
                //.ForMember(bookItem => bookItem.Tags, opt => opt.Ignore())
                .ForMember(bookItem => bookItem.Tags, opt => opt.ConvertUsing<ArrayStringConverter, string[]>())
                .ForMember(bookItem => bookItem.Rating, opt => opt.MapFrom(book => book.Rating))
                .ForMember(bookItem => bookItem.Description, opt => opt.MapFrom(book => book.Description));
        }
    }
}

internal class ArrayStringConverter : IValueConverter<string[], string[]>
{
    public string[] Convert(string[] Tags, ResolutionContext context)
    {
        string[] TagsCopy = new string[Tags.Length];
        Array.Copy(Tags, TagsCopy, Tags.Length);
        return TagsCopy;
    }
}
