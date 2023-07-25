namespace RealEstate.Domain.Entities
{
    public class Entity
    {
        public short id { get; set; }
        public string? value { get; set; }
        public short entityGroupId { get; set; }

        public EntityGroup entityGroup { get; set; }
        public ICollection<Product> propertyTypeEntity { get; set; }
        public ICollection<Product> furnitureConditionEntity { get; set; }
        public ICollection<Product> numberOfRoomsEntity { get; set; }
        public ICollection<Product> floorLevelEntity { get; set; }
        public ICollection<Product> buildingAgeEntity { get; set; }
    }
}

