using System.Security.Cryptography.X509Certificates;
using CustomerService.Utilities.Abstract;

namespace CustomerService.Utilities.Concrete
{
    public class Result : ICustomResult
    {
        public Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
