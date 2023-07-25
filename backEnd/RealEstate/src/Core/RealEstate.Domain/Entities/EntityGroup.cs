namespace RealEstate.Domain.Entities
{
    public class EntityGroup
    {
        public short id { get; set; }
        public string? value { get; set; }
        public ICollection<Entity> entity { get; set; }
    }
}

