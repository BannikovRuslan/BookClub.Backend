using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using BookClub.Application.Presentations.ViewModels;

namespace BookClub.Application.Presentations.Commands
{
    public class UpdatePresentationCommandHandler : IRequestHandler<UpdatePresentationCommand, PresentationDetailsVm>
    {
        private readonly IMapper _mapper;
        public UpdatePresentationCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<PresentationDetailsVm> Handle(UpdatePresentationCommand request, CancellationToken cancellationToken)
        {

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var presentationUpdate = _mapper.Map<Presentation>(request);
            var entity = new Presentation();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                entity.Date = presentationUpdate.Date;
                entity.Rating= presentationUpdate.Rating;
                entity.UrlPresentation = presentationUpdate.UrlPresentation;
                entity.UrlVideo = presentationUpdate.UrlVideo;
                entity.Review = presentationUpdate.Review;
                entity.Book = presentationUpdate.Book;
                entity.Speaker = presentationUpdate.Speaker;
                entity.Meeting = presentationUpdate.Meeting;
                ds.UpdateObject(entity);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<PresentationDetailsVm>(entity);
        }
    }
}
