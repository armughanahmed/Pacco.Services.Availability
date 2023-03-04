using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class InvalidAggregateIdException : DomainException
    {
        public Guid Id { get; }
        public InvalidAggregateIdException(Guid id) : base($"Invalid Aggregate ID : '{id}'.")
        {
            Id = id;
        }
    }
}
