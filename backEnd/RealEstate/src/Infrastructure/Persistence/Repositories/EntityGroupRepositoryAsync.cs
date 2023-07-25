using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using RealEstate.Application.Interfaces.Persistence.Repositories;
using RealEstate.Domain.Entities;

namespace Persistence.Repositories
{
    public class EntityGroupRepositoryAsync : GenericRepositoryAsync<EntityGroup>, IEntityGroupRepositoryAsync
    {
        private readonly DbSet<EntityGroup> _entityGroup;

        public EntityGroupRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _entityGroup = dbContext.Set<EntityGroup>();
        }

        public async Task<IEnumerable<EntityGroup>> GetAllWithEntityAsync()
        {
            var result = await _entityGroup
                   .Include(p => p.entity)
                   .AsNoTracking()
                   .ToListAsync();

            return result; 
        }
    }
}

