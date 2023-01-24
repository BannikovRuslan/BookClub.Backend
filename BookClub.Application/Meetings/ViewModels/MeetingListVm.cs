using BookClub.Application.Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Meetings.ViewModels
{
    public class MeetingListVm
    {
        public IList<MeetingDetailsVm> Meetings { get; set; }
    }
}
