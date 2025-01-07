using CustomerService.Data.Abstract;
using CustomerService.Data.Concrete;
using CustomerService.Models;
using CustomerService.Services.Abstract;
using CustomerService.Services.Concrete;
using CustomerService.Services.ValidationRules;
using FluentValidation;

namespace CustomerService.Utilities.Concrete
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<ICustomerService,Services.Concrete.CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IValidator<Customer>, CustomerValidator>();
        }
    }
}
