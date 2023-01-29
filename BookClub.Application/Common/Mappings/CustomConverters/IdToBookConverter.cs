using AutoMapper;
using BookClub.Domains;
using ICSSoft.STORMNET.Business;
using System;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class IdToBookConverter : IValueConverter<Guid, Book>
    {
        public Book Convert(Guid Id, ResolutionContext context)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var data = new Book();
            data.SetExistObjectPrimaryKey(Id);
            ds.LoadObject(data);
            return data;
        }
    }
}
