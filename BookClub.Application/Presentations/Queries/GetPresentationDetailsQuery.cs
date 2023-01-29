using BookClub.Application.Presentations.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Presentations.Queries
{
    public class GetPresentationDetailsQuery : IRequest<PresentationDetailsVm>
    {
        public Guid Id { get; set; }

    }
}
