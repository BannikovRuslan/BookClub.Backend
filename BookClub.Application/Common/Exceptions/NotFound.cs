using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.Application.Common.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string name, object key) : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
