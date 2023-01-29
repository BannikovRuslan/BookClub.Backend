using BookClub.Application.Meetings.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Meetings.Quries
{
    public class GetMeetingDetailsQuery : IRequest<MeetingDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
