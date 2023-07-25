using AutoMapper;
using RealEstate.Application.Features.EntityGroup.Tools.Dtos;

namespace RealEstate.Application.Features.EntityGroup.Tools.Mappings
{
    public class EntityGroupProfile : Profile
    {
        public EntityGroupProfile()
        {
            CreateMap<EntityGroupDto, Domain.Entities.EntityGroup>().ReverseMap();
        }
    }
}

