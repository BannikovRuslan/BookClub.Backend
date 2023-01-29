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
    public class CreatePresentationCommandHandler : IRequestHandler<CreatePresentationCommand, PresentationDetailsVm>
    {
        private readonly IMapper _mapper;
        public CreatePresentationCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<PresentationDetailsVm> Handle(CreatePresentationCommand request, CancellationToken cancellationToken)
        {
            var presentation = _mapper.Map<Presentation>(request);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            try
            {
                ds.UpdateObject(presentation);
            }
            catch (Exception)
            {

                throw;
            }

            presentation.Id = Guid.Parse(presentation.__PrimaryKey.ToString());
            return _mapper.Map<PresentationDetailsVm>(presentation);
        }
    }
}
