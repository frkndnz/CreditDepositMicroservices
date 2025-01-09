using System.Security.Cryptography.X509Certificates;
using CustomerService.Utilities.Abstract;
using FluentValidation.Results;

namespace CustomerService.Utilities.Concrete
{
    public class Result 
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public List<ValidationFailure> Errors { get; private set; }

        private Result()
        {
            Errors = new List<ValidationFailure>();
        }
        public static Result Success(string message = null)
        {
            return new Result
            {
                IsSuccess = true,
                Message = message ?? "Operation completed successfully",
                
            };
        }

        public static Result Failure(string message)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static Result ValidationFailure(IEnumerable<ValidationFailure> errors)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "Validation failed",
                Errors = errors.ToList()
            };
        }

        public static Result ValidationFailure(ValidationResult validationResult)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "Validation failed",
                Errors = validationResult.Errors
            };
        }
    }
}
