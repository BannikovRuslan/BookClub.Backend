using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class StringArrayToString : IValueConverter<string[], string>
    {
        public string Convert(string[] Tags, ResolutionContext context)
        {
            string TagsCopy = string.Join(separator: ',', Tags);
            return TagsCopy;
        }
    }
}
