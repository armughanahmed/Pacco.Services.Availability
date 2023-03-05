using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.Exceptions
{
    public class ResourceAlreadyExistsException : AppException
    {
        public ResourceAlreadyExistsException(Guid id) : base($"Resource with ID: '{id}' already exists.")
        {
        }
    }
}
