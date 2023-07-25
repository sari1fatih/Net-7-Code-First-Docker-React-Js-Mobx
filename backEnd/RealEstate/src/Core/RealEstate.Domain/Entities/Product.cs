using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public short propertyTypeEntityId { get; set; }
        public short furnitureConditionEntityId { get; set; }
        public short numberOfRoomsEntityId { get; set; }
        public short floorLevelEntityId { get; set; }
        public short buildingAgeEntityId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int totalSquareFootage { get; set; }
        public Entity propertyTypeEntity { get; set; }
        public Entity furnitureConditionEntity { get; set; }
        public Entity numberOfRoomsEntity { get; set; }
        public Entity floorLevelEntity { get; set; }
        public Entity buildingAgeEntity { get; set; }
        public ICollection<ProductPhoto> productPhoto { get; set; }
    }
}

