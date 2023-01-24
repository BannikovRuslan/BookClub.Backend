using AutoMapper;
using BookClub.Application.Books.Commands;
using BookClub.Application.Books.ViewModels;
using BookClub.Application.Common.Exceptions;
using BookClub.Application.Interfaces;
using BookClub.Application.Speakers.ViewModels;
using BookClub.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ICSSoft.STORMNET.Business;


namespace BookClub.Application.Speakers.Commands
{
    public class UpdateSpeakerCommandHandler : IRequestHandler<UpdateSpeakerCommand, SpeakerDetailsVm>
    {
        private readonly ISpeakersDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateSpeakerCommandHandler(ISpeakersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<SpeakerDetailsVm> Handle(UpdateSpeakerCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _dbContext.Speakers.FirstOrDefaultAsync(speaker => speaker.Id == request.Id, cancellationToken);
            //if (entity == null)
            //{
            //    throw new NotFound(nameof(Book), request.Id);
            //}
            //entity.FirstName = request.FirstName;
            //entity.LastName = request.LastName;
            //entity.MiddleName = request.MiddleName;
            //entity.Foto = request.Foto;
            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            var entity = new Speaker();
            try
            {
                entity.SetExistObjectPrimaryKey(request.Id);
                ds.LoadObject(entity);
                // entity = _mapper.Map<Speaker>(request);
                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.MiddleName= request.MiddleName;
                entity.Foto= request.Foto;
                ds.UpdateObject(entity);
            }
            catch (Exception)
            {

                throw;
            }

            return _mapper.Map<SpeakerDetailsVm>(entity);
        }
    }
}
