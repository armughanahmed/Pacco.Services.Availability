using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public virtual string Code { get; set; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}
