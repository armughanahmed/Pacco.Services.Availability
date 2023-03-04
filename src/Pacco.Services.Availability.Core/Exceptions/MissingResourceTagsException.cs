using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class MissingResourceTagsException : DomainException
    {
        public MissingResourceTagsException() : base($"Missing tags for the resource.")
        {
        }
    }
}
