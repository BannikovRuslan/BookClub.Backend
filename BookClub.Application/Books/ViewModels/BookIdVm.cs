using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Domains;
using System;

namespace BookClub.Application.Books.ViewModels
{
    public class BookIdVm : IMapWith<Book>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookIdVm>()
                .ForMember(bookVm => bookVm.Id, opt => opt.MapFrom(book => book.Id));
        }
    }
}
