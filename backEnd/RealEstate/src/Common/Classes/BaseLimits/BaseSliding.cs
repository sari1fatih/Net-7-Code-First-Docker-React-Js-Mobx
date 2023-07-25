namespace Common.Classes.BaseLimits
{
    public class BaseSliding
	{
        public int FromMinute { get; set; }
        public int PermitLimit { get; set; }
        public int QueueLimit { get; set; }
        public int SegmentsPerWindow { get; set; }
    }
}

