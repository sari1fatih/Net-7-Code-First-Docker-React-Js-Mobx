using RealEstate.Application.Features.Entity.Tools.Dtos;

namespace RealEstate.Application.Features.Product.Tools.Dtos
{
    public class BaseProductDto
	{
        public virtual int id { get; set; }
        public short propertyTypeEntityId { get; set; }
        public string propertyTypeEntityValue { get; set; }

        public short furnitureConditionEntityId { get; set; }
        public string furnitureConditionEntityValue { get; set; }

        public short numberOfRoomsEntityId { get; set; }
        public string numberOfRoomsEntityValue { get; set; }

        public short floorLevelEntityId { get; set; }
        public string floorLevelEntityValue { get; set; }

        public short buildingAgeEntityId { get; set; }
        public string buildingAgeEntityValue { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int totalSquareFootage { get; set; }
    }
}

