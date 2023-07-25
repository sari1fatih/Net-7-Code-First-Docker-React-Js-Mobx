using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using RealEstate.Application.Interfaces.Persistence.Repositories;
using RealEstate.Domain.Entities;

namespace Persistence.Repositories
{
    public class ProductPhotoRepositoryAsync : GenericRepositoryAsync<ProductPhoto>, IProductPhotoRepositoryAsync
    {
        private readonly DbSet<ProductPhoto> _productPhoto;

        public ProductPhotoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _productPhoto = dbContext.Set<ProductPhoto>();
        }
    }
}

