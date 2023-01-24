using AutoMapper;
using System;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class StringArrayToStringArray : IValueConverter<string[], string[]>
    {
        public string[] Convert(string[] Tags, ResolutionContext context)
        {
            string[] TagsCopy = new string[Tags.Length];
            Array.Copy(Tags, TagsCopy, Tags.Length);
            return TagsCopy;
        }
    }
}
