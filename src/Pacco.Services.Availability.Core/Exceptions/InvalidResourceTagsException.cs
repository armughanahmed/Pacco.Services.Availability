using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class InvalidResourceTagsException : DomainException
    {
        public InvalidResourceTagsException() : base($"Invalid tags for the resource.")
        {
        }
    }
}
