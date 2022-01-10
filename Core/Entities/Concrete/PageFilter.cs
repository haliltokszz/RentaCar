namespace Core.Entities.Concrete
{
    public class PageFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Column { get; set; } = "CreatedTime";
        public bool Descending { get; set; } = false;
        public PageFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PageFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}