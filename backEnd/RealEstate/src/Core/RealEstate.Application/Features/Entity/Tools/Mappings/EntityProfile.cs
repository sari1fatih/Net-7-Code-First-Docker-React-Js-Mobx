using AutoMapper;
using RealEstate.Application.Features.Entity.Tools.Dtos;
using RealEstate.Application.Features.EntityGroup.Tools.Dtos;

namespace RealEstate.Application.Features.Entity.Tools.Mappings
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<EntityGroupDto, Domain.Entities.EntityGroup>().ReverseMap();
            CreateMap<EntityDto, Domain.Entities.Entity>().ReverseMap();
        }
    }
}

