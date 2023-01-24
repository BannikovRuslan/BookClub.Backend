using AutoMapper;

namespace BookClub.Application.Common.Mappings.CustomConverters
{
    public class StringToStringArray : IValueConverter<string, string[]>
    {
        public string[] Convert(string Tags, ResolutionContext context)
        {
            string[] TagsCopy = Tags.Split(separator: ',');
            return TagsCopy;
        }

    }
}
