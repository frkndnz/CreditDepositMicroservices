using CustomerService.Models;

namespace CustomerService.Data.Abstract
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
