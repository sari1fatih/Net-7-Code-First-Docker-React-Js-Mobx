using AutoMapper;
using RealEstate.Application.Features.Product.Tools.Dtos;
using RealEstate.Application.Features.ProductPhoto.Tools.Dtos;

namespace RealEstate.Application.Features.ProductPhoto.Tools.Mappings
{
    public class ProductPhotoProfile : Profile
    {
        public ProductPhotoProfile()
        {
            CreateMap<ProductPhotoDto, Domain.Entities.ProductPhoto>().ReverseMap();
            CreateMap<ProductByIdDto, Domain.Entities.ProductPhoto>().ReverseMap();             
        }
    }
}