using CustomerService.Data.Abstract;
using CustomerService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Data.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        private readonly DbSet<Customer> _customerSet;
        public CustomerRepository(Context context)
        {
            _context = context;
            _customerSet = context.Set<Customer>();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerSet.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerSet.FirstOrDefaultAsync(c=>c.Id==id);
            _customerSet.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer=await _customerSet.FindAsync(id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers=await _customerSet.ToListAsync();
            return customers;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
