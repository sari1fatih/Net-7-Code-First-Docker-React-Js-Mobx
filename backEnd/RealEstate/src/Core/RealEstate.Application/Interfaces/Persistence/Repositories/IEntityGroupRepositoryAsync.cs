using RealEstate.Domain.Entities;

namespace RealEstate.Application.Interfaces.Persistence.Repositories
{
    public interface IEntityGroupRepositoryAsync : IGenericRepositoryAsync<EntityGroup>
    {
        public Task<IEnumerable<EntityGroup>> GetAllWithEntityAsync();

    }
}

