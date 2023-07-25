using RealEstate.Application.Features.EntityGroup.Tools.Dtos;

namespace RealEstate.Application.Features.Entity.Tools.Dtos
{
    public class EntityDto
    {
        public short id { get; set; }
        public string? value { get; set; }
        public short entityGroupId { get; set; }
    }
}

