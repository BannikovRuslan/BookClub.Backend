﻿using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using System;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class IdToSpeakerConverter : IValueConverter<Guid, Speaker>
    {
        public Speaker Convert(Guid Id, ResolutionContext context)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var data = new Speaker();
            data.SetExistObjectPrimaryKey(Id);
            ds.LoadObject(data);
            return data;
        }
    }
}
