using AutoMapper;
using Common.Classes.Exceptions;
using Common.Classes.Wrappers;
using RealEstate.Application.Features.Product.Queries;
using RealEstate.Application.Features.Product.Tools.Constraints;
using RealEstate.Application.Features.Product.Tools.Dtos;
using RealEstate.Application.Interfaces.Application.Features.Product;
using RealEstate.Application.Interfaces.Persistence.Repositories;

namespace RealEstate.Application.Features.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;
        protected IMapper _mapper;

        public ProductManager(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
        {
            _productRepositoryAsync = productRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProductDto>>> GetList(GetAllProductQuery getAllProductQuery)
        {
            var product = await _productRepositoryAsync.GetBySearchAsync(getAllProductQuery);
            if (product == null) throw new ApiException(ProductConstraint.ProductNotFound);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);           
            return new PagedResponse<IEnumerable<ProductDto>>(productDto, getAllProductQuery);
        }

        public async Task<Response<ProductByIdDto>> GetById(GetProductByIdQuery getProductById)
        {
            var product = await _productRepositoryAsync.GetByIdAsync(getProductById.id);
            if (product == null) throw new ApiException(ProductConstraint.ProductNotFound);
            var productDto = _mapper.Map<ProductByIdDto>(product);
            return new Response<ProductByIdDto>(productDto);
        }
    }
}

