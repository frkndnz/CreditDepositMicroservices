using Microsoft.EntityFrameworkCore;
using CustomerService.Models;

namespace CustomerService.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
