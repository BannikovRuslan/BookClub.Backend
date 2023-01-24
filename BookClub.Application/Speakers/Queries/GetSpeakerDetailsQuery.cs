using BookClub.Application.Speakers.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Speakers.Queries
{
    public class GetSpeakerDetailsQuery : IRequest<SpeakerDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
