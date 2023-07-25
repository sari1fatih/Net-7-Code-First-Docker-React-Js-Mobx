using Common.Classes.Wrappers;
using RealEstate.Application.Features.Product.Queries;
using RealEstate.Application.Features.Product.Tools.Dtos;

namespace RealEstate.Application.Interfaces.Application.Features.Product
{
    public interface IProductManager
    {
        Task<PagedResponse<IEnumerable<ProductDto>>> GetList(GetAllProductQuery getAllProductQuery);
        Task<Response<ProductByIdDto>> GetById(GetProductByIdQuery getProductById);
    }
}

