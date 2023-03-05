using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Documents
{
    internal sealed class ReservationDocument
    {
        public int TimeStamp { get; set; }
        public int Priority { get; set; }
    }
}
