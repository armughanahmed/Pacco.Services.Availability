using Convey.Persistence.MongoDB;
using Pacco.Services.Availability.Core.Entities;
using Pacco.Services.Availability.Core.Repositories;
using Pacco.Services.Availability.Infrastructure.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Repositories
{
    internal sealed class ResourcesMongoRepository : IResourcesRepository
    {
        IMongoRepository<ResourceDocument, Guid> _repository;
        public ResourcesMongoRepository(IMongoRepository<ResourceDocument, Guid> repository) => _repository = repository;

        public async Task<Resource> GetAsync(AggregateId id)
        {
            var document = await _repository.GetAsync(x => x.Id == id);

            return document?.AsEntity();
        }

        public Task AddAsync(Resource resource) => _repository.AddAsync(resource.AsDocument());

        public Task UpdateAsync(Resource resource) => _repository.UpdateAsync(resource.AsDocument(), x => x.Id == resource.Id && x.Version < resource.Version);

        public Task DeleteAsync(AggregateId id) => _repository.DeleteAsync(id);
    }
}
