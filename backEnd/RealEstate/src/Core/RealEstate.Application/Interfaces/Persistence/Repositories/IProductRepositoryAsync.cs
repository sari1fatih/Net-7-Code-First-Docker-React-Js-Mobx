using RealEstate.Application.Features.Product.Queries;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Interfaces.Persistence.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> GetBySearchAsync(GetAllProductQuery getAllProductQuery);
    }
}

