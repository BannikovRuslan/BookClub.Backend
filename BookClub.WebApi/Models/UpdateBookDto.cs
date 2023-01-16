using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.WebApi.Models
{
    public class UpdateBookDto : IMapWith<UpdateBookCommand>
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        //public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
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
