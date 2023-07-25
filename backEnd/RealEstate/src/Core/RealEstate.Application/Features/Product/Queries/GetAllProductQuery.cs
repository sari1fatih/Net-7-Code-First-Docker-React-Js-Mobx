using Common.Classes.Queries;

namespace RealEstate.Application.Features.Product.Queries
{
    public class GetAllProductQuery : BasePageQuery
    { 
        public string search { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public List<short> buildingAgeEnum { get; set; } 
        public List<short> floorLevelEnum { get; set; } 
        public List<short> furnitureConditionEnum { get; set; }
        public List<short> numberOfRoomsEnum { get; set; }
        public List<short> propertyTypeEnum { get; set; }
    }
}

