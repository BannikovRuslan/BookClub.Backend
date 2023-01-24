using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Common.Mappings.CustomConverters;
using BookClub.Domains;
using System;

namespace BookClub.Application.Books.ViewModels
{
    // View Model то, что будет возвращаться пользователю
    public class BookDetailsVm : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(bookVm => bookVm.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.Cover, opt => opt.MapFrom(book => book.Cover == null ? "" : book.Cover))
                .ForMember(bookVm => bookVm.Title, opt => opt.MapFrom(book => book.Title == null ? "" : book.Title))
                .ForMember(bookVm => bookVm.Author, opt => opt.MapFrom(book => book.Author == null ? "" : book.Author))
                .ForMember(bookVm => bookVm.Pages, opt => opt.MapFrom(book => book.Pages))
                .ForMember(bookVm => bookVm.Tags, opt => opt.ConvertUsing(new StringToStringArray()))
                .ForMember(bookVm => bookVm.Rating, opt => opt.MapFrom(book => book.Rating))
                .ForMember(bookVm => bookVm.Description, opt => opt.MapFrom(book => book.Description));
        }
    }
}
