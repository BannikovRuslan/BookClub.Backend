using BookClub.Application.Meetings.ViewModels;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Presentations.Queries
{
    public class GetPresentationListQuery : IRequest<PresentationListVm>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string UrlPresentation { get; set; }
        public string UrlVideo { get; set; }
        public string Review { get; set; }
        public Book Book { get; set; }
        public Speaker Speaker { get; set; }
        public Meeting Meeting { get; set; }
    }
}
