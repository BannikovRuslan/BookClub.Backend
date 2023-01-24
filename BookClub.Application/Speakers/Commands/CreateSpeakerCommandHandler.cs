using BookClub.Application.Speakers.Commands;
using BookClub.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.KeyGen;
using BookClub.Domains;

namespace BookClub.Application.Speakers.Commands
{
    public class CreateSpeakerCommandHandler : IRequestHandler<CreateSpeakerCommand, Speaker>
    {
        private readonly ISpeakersDbContext _dbContext;
        public CreateSpeakerCommandHandler(ISpeakersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Speaker> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speaker = new Speaker
            {
                FirstName= request.FirstName,
                LastName= request.LastName,
                MiddleName= request.MiddleName,
                Foto= request.Foto,
            };

            //await _dbContext.Speakers.AddAsync(speaker, cancellationToken);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            var ds = (SQLDataService)DataServiceProvider.DataService;
            try
            {
                ds.UpdateObject(speaker);
            }
            catch (Exception)
            {

                throw;
            }

            speaker.Id = Guid.Parse(speaker.__PrimaryKey.ToString());
            return speaker;
        }
    }
}
