using CustomerService.Models;
using FluentValidation;

namespace CustomerService.Services.ValidationRules
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format."); // E.164 format

            RuleFor(x => x.DateofBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Today).WithMessage("Date of birth cannot be in the future.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address can be at most 200 characters long.");

            RuleFor(x => x.NationalId)
                .Matches(@"^\d{11}$").WithMessage("National ID must be 11 digits.");
        }
    }
}
