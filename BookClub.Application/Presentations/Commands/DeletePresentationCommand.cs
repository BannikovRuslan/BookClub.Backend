using BookClub.Application.Presentations.ViewModels;
using MediatR;
using System;


namespace BookClub.Application.Presentations.Commands
{
    public class DeletePresentationCommand : IRequest<PresentationIdVm>
    {
        public Guid Id { get; set; }
    }
}
