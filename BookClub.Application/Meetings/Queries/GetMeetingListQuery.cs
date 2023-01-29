using BookClub.Application.Meetings.ViewModels;
using MediatR;
using System;

namespace BookClub.Application.Meetings.Quries
{
    public class GetMeetingListQuery : IRequest<MeetingListVm>
    {
        public Guid Id { get; set; }
        public DateTime? SearchDate { get; set; }
        public int page { get; set; }   
        public int limit { get; set; }
    }
}
