using Convey.CQRS.Queries;
using Pacco.Services.Availability.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.Queries
{
    public class GetResource : IQuery<ResourceDto>
    {
        public Guid ResourceId { get; set; }
    }
}
