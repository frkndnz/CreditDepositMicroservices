using CustomerService.DTOs;
using CustomerService.Utilities.Concrete;

namespace CustomerService.Services.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomersAsync();
        Task<CustomerDTO> GetCustomerAsync(int id);
        Task<Result> AddCustomerAsync(CreateCustomerDTO customer);
        Task<Result> UpdateCustomerAsync(CreateCustomerDTO customer);
        Task<Result> DeleteCustomerAsync(int id);
    }
}
