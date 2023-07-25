using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class ProductPhoto : AuditableBaseEntity
    {
        public int productId { get; set; }
        public string url { get; set; }
        public Product product { get; set; }
    }
}

