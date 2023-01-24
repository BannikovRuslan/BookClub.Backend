using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Speakers.Commands
{
    public class CreateSpeakerCommand: IRequest<Speaker>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Foto { get; set; }
    }
}
