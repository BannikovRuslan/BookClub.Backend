using BookClub.Application.Meetings.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Meetings.Commands
{
    public class DeleteMeetingCommand : IRequest<MeetingIdVm>
    {
        public Guid Id { get; set; }
    }
}
