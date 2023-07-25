using RealEstate.Application.Features.Entity.Tools.Dtos;

namespace RealEstate.Application.Features.EntityGroup.Tools.Dtos
{
    public class EntityGroupDto
    {
        public short id { get; set; }
        public string? value { get; set; }
        public ICollection<EntityDto> entity { get; set; }
    }
}

 