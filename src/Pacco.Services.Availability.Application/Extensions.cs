using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder) 
            => builder.AddCommandHandlers()
                      .AddInMemoryQueryDispatcher();
    }
}
