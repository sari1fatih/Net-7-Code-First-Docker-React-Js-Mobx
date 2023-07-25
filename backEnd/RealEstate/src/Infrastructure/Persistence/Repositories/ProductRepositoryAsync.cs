using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using RealEstate.Application.Features.Product.Queries;
using RealEstate.Application.Interfaces.Persistence.Repositories;
using RealEstate.Domain.Entities;

namespace Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _product;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _product = dbContext.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetBySearchAsync(GetAllProductQuery getAllProductQuery)
        {
            var result = _product
                   .Include(p => p.propertyTypeEntity)
                   .Include(p => p.furnitureConditionEntity)
                   .Include(p => p.numberOfRoomsEntity)
                   .Include(p => p.floorLevelEntity)
                   .Include(p => p.buildingAgeEntity)
                   .Include(p => p.productPhoto)
                   .Where(p =>
                     (
                         (
                           string.IsNullOrEmpty(getAllProductQuery.search) ||
                           (
                               !string.IsNullOrEmpty(getAllProductQuery.search) &&
                               ((p.title ?? "") + (p.description ?? "")).ToLower()
                               .Contains(getAllProductQuery.search.ToLower())
                           )
                         ) &&
                         (
                           (getAllProductQuery.minPrice == 0 && getAllProductQuery.maxPrice == 0) ||
                           (getAllProductQuery.maxPrice!=0  && getAllProductQuery.minPrice == 0 && p.price <= getAllProductQuery.maxPrice) ||
                           (getAllProductQuery.minPrice!=0 && getAllProductQuery.minPrice >= p.price && p.price == 0) ||
                           (getAllProductQuery.minPrice != 0 && getAllProductQuery.maxPrice != 0 && getAllProductQuery.minPrice >= p.price && p.price <= getAllProductQuery.maxPrice)
                         ) &&

                         (                            
                            (
                                getAllProductQuery.buildingAgeEnum == null ||

                                !getAllProductQuery.buildingAgeEnum.Any()
                            ) ||
                            (
                                getAllProductQuery.buildingAgeEnum != null &&
                                getAllProductQuery.buildingAgeEnum.Contains(p.buildingAgeEntityId)
                            )

                         ) &&
                         (
                           (
                                getAllProductQuery.floorLevelEnum == null ||

                                !getAllProductQuery.floorLevelEnum.Any()
                           ) ||

                           (
                                getAllProductQuery.floorLevelEnum != null &&
                                getAllProductQuery.floorLevelEnum.Contains(p.floorLevelEntityId)
                           )

                         ) &&

                         (
                           (
                                getAllProductQuery.furnitureConditionEnum == null ||

                                !getAllProductQuery.furnitureConditionEnum.Any()
                           ) ||

                           (
                                getAllProductQuery.furnitureConditionEnum != null &&
                                getAllProductQuery.furnitureConditionEnum.Contains(p.furnitureConditionEntityId)
                           )

                         ) &&

                         (
                           (
                                getAllProductQuery.numberOfRoomsEnum == null ||

                                !getAllProductQuery.numberOfRoomsEnum.Any()
                           ) ||

                           (
                                getAllProductQuery.numberOfRoomsEnum != null &&
                                

                                getAllProductQuery.numberOfRoomsEnum.Contains(p.numberOfRoomsEntityId)
                           )

                         ) &&

                         (
                           (
                                getAllProductQuery.propertyTypeEnum == null ||

                                !getAllProductQuery.propertyTypeEnum.Any()
                           ) ||

                           (
                                getAllProductQuery.propertyTypeEnum != null &&
                                getAllProductQuery.propertyTypeEnum.Contains(p.propertyTypeEntityId)
                           )

                         )
                     )

                   )
                   .Skip((getAllProductQuery.pageNumber - 1) * getAllProductQuery.pageSize)
                   .Take(getAllProductQuery.pageSize)
                   .AsNoTracking()
                   .ToList();

            return result;
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            var result = _product
                   .Include(p => p.propertyTypeEntity)
                   .Include(p => p.furnitureConditionEntity)
                   .Include(p => p.numberOfRoomsEntity)
                   .Include(p => p.floorLevelEntity)
                   .Include(p => p.buildingAgeEntity)
                   .Include(p => p.productPhoto)
                   .Where(p => p.id == id)
                   .FirstOrDefault();
            return result;
        }

    }
}