namespace CustomerService.Utilities.Abstract
{
    public interface ICustomResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
       
    }
}
