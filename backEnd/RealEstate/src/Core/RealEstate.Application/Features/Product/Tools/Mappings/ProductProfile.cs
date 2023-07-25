using AutoMapper;
using RealEstate.Application.Features.Product.Tools.Dtos;

namespace RealEstate.Application.Features.Product.Tools.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>()
                .ForMember(dest => dest.productPhotoUrl, opt => opt.MapFrom(src => GetProductPhotoUrl(src.productPhoto)))
                .ReverseMap();

            CreateMap<Domain.Entities.Product, ProductByIdDto>()
                .ForMember(dest => dest.productPhotoUrls, opt => opt.MapFrom(src => src.productPhoto.Select(photo => photo.url).ToList()))
                .ReverseMap();
        }
        private string GetProductPhotoUrl(ICollection<Domain.Entities.ProductPhoto> productPhoto)
        {
            if (productPhoto != null && productPhoto.Any())
            {
                return productPhoto.First().url;
            }

            return null; 
        }
    }
}

