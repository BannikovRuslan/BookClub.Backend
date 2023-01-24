using AutoMapper;
using BookClub.Application.Common.Mappings;
using BookClub.Application.Common.Mappings.CustomConverters;
using BookClub.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookClub.Application.Speakers.ViewModels
{
    public class SpeakerListVm
    {
        public IList<SpeakerDetailsVm> Speakers { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<IQueryable<Speaker>, IList<SpeakerDetailsVm>>()
        //        .ForMember(speakerVm => speakerVm, opt => opt.ConvertUsing(new ObjectQueryToObjectIList()));
        //}
    }

    public class ObjectQueryToObjectIList : IValueConverter<IQueryable<Speaker>, IList<SpeakerDetailsVm>>
    {
        public IList<SpeakerDetailsVm> Convert(IQueryable<Speaker> objects, ResolutionContext context)
        {

            IList<SpeakerDetailsVm> newObjects = new List<SpeakerDetailsVm>();
            foreach (Speaker obj in objects)
            {
                SpeakerDetailsVm speakerDetailsNew= new SpeakerDetailsVm();
                speakerDetailsNew.Id = obj.Id;
                speakerDetailsNew.FirstName = obj.FirstName;
                speakerDetailsNew.LastName = obj.LastName;
                speakerDetailsNew.MiddleName = obj.MiddleName;
                speakerDetailsNew.Foto = obj.Foto;
                newObjects.Add(speakerDetailsNew);
            }
            return newObjects;
        }
    }
}
