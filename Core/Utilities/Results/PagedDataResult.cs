namespace Core.Utilities.Results
{
    public class PagedDataResult<T> : DataResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedDataResult(T data, bool success, string message, int pageNumber, int pageSize): base(data, success, message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public PagedDataResult(T data, bool success, int pageNumber, int pageSize) : base(data, success)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        
    }
}