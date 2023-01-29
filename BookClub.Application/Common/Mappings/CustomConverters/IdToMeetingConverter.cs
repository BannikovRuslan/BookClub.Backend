using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using System;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class IdToMeetingConverter : IValueConverter<Guid, Meeting>
    {
        public Meeting Convert(Guid Id, ResolutionContext context)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var data = new Meeting();
            data.SetExistObjectPrimaryKey(Id);
            ds.LoadObject(data);
            return data;
        }
    }
}
