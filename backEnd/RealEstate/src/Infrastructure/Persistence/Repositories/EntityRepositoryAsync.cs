using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using RealEstate.Application.Interfaces.Persistence.Repositories;
using RealEstate.Domain.Entities;

namespace Persistence.Repositories
{
    public class EntityRepositoryAsync : GenericRepositoryAsync<Entity>, IEntityRepositoryAsync
    {
        private readonly DbSet<Entity> _entity;

        public EntityRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _entity = dbContext.Set<Entity>();
        }
    }
}

