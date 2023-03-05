using Pacco.Services.Availability.Application.DTO;
using Pacco.Services.Availability.Core.Entities;
using Pacco.Services.Availability.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static Resource AsEntity(this ResourceDocument document) => 
            new Resource(
                document.Id,
                document.Tags,
                document.Reservations.Select(x => new Reservation(x.TimeStamp.AsDateTime(), x.Priority)));

        public static ResourceDocument AsDocument(this Resource entity) => new ResourceDocument
        {
            Id = entity.Id,
            Version = entity.Version,
            Tags = entity.Tags,
            Reservations = entity.Reservations.Select(x => new ReservationDocument
            {
                TimeStamp = x.DateTime.AsDaysSinceEpoch(),
                Priority = x.Priority,
            })
        };

        public static ResourceDto AsDto(this ResourceDocument document) => new ResourceDto
        {
            Id = document.Id,
            Tags = document.Tags ?? Enumerable.Empty<string>(),
            Reservations = document.Reservations?.Select(x => new ReservationDto
            {
                Priority = x.Priority,
                DateTime = x.TimeStamp.AsDateTime(),
            }) ?? Enumerable.Empty<ReservationDto>()
        };

        public static int AsDaysSinceEpoch(this DateTime dateTime) => (dateTime - new DateTime()).Days;
        public static DateTime AsDateTime(this int daysSinceEpoch) => new DateTime().AddDays(daysSinceEpoch);
    }
}
