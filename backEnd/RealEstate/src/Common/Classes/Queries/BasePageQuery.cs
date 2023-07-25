namespace Common.Classes.Queries
{
    public class BasePageQuery
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public BasePageQuery()
        {
            pageNumber = 1;
            pageSize = 30;
        }
        public BasePageQuery(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.pageSize = pageSize > 30 ? 30 : pageSize;
        }
    }
}

