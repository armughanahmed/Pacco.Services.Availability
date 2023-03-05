using Convey.CQRS.Queries;
using MongoDB.Driver;
using Pacco.Services.Availability.Application.DTO;
using Pacco.Services.Availability.Application.Queries;
using Pacco.Services.Availability.Infrastructure.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Queries.Handlers
{
    internal sealed class GetResourcesHandler : IQueryHandler<GetResources, IEnumerable<ResourceDto>>
    {
        private readonly IMongoDatabase _database;

        public GetResourcesHandler(IMongoDatabase database)
        {
            _database= database;
        }

        public async Task<IEnumerable<ResourceDto>> HandleAsync(GetResources query)
        {
            var collection = _database.GetCollection<ResourceDocument>("resources");

            if (query.Tags is null || !query.Tags.Any())
            {
                var allDocuments = await collection.Find(_ => true).ToListAsync();
                return allDocuments.Select(x => x.AsDto());
            }

            var documents = collection.AsQueryable();

            documents = (MongoDB.Driver.Linq.IMongoQueryable<ResourceDocument>)(query.MatchAllTags ? documents.Where(x => query.Tags.All(y => x.Tags.Contains(y))) : documents.Where(x => query.Tags.Any(y => x.Tags.Contains(y))));

            var resources = await documents.ToListAsync();

            return resources.Select(x => x.AsDto());
        }
    }
}
