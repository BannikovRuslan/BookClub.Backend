using BookClub.Application.Speakers.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Speakers.Commands
{
    public class DeleteSpeakerCommand : IRequest<SpeakerIdVm>
    {
        public Guid Id { get; set; }
    }
}
