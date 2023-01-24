using BookClub.Application.Speakers.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Speakers.Queries
{
    public class GetSpeakerListQuery : IRequest<SpeakerListVm>
    {
        public int Id { get; set; }
        public string SearchText { get; set; }
    }
}
