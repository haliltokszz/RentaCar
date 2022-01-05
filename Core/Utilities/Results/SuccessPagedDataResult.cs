namespace Core.Utilities.Results
{
    public class SuccessPagedDataResult<T>: PagedDataResult<T>
    {
        public SuccessPagedDataResult(T data, string message, int pageNumber, int pageSize) : base(data, true, message, pageNumber, pageSize)
        {
        }

        public SuccessPagedDataResult(T data) : base(data, true, 1, 10)
        {
        }
        public SuccessPagedDataResult(string message) : base(default, true, message, 1,10)
        {
        }
    }
}