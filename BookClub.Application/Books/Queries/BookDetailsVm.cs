using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookClub.Application.Books.Queries
{
    // View Model то, что будет возвращаться пользователю
    public class BookDetailsVm : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
       // public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(bookVm => bookVm.Id, opt => opt.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.Cover, opt => opt.MapFrom(book => book.Cover))
                .ForMember(bookVm => bookVm.Title, opt => opt.MapFrom(book => book.Title))
                .ForMember(bookVm => bookVm.Author, opt => opt.MapFrom(book => book.Author))
                .ForMember(bookVm => bookVm.Pages, opt => opt.MapFrom(book => book.Pages))
                //.ForMember(bookVm => bookVm.Tags, opt => opt.Ignore())
                .ForMember(bookVm => bookVm.Rating, opt => opt.MapFrom(book => book.Rating))
                .ForMember(bookVm => bookVm.Description, opt => opt.MapFrom(book => book.Description));
        }
    }
}
