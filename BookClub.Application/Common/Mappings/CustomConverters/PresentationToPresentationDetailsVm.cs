using AutoMapper;
using BookClub.Application.Presentations.ViewModels;
using BookClub.Domains;
using System.Collections.Generic;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class PresentationToPresentationDetailsVm : IValueConverter<DetailArrayOfPresentation, List<PresentationDetailsVm>>
    {
        public List<PresentationDetailsVm> Convert(DetailArrayOfPresentation presentations, ResolutionContext context)
        {
            List<PresentationDetailsVm> presentationDetailsVms = new List<PresentationDetailsVm>();

            foreach (var item in presentations)
            {
                Presentation presentation = item as Presentation;
                PresentationDetailsVm pVm = new PresentationDetailsVm()
                {
                    Id = presentation.Id,
                    Date = presentation.Date,
                    Rating = presentation.Rating,
                    UrlPresentation = presentation.UrlPresentation == null ? "" : presentation.UrlPresentation,
                    UrlVideo = presentation.UrlVideo == null ? "" : presentation.UrlVideo,
                    Review = presentation.Review == null? "" : presentation.Review,
                    SpeakerId = presentation.Speaker.Id,
                    BookId = presentation.Book.Id,
                    MeetingId = presentation.Meeting.Id
                };
                presentationDetailsVms.Add(pVm);
            }

            
            return presentationDetailsVms;
        }
    }
}
