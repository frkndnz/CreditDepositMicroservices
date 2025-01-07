using CustomerService.DTOs;
using CustomerService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController:Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers=await _customerService.GetCustomersAsync();

           return customers.Any() ? Ok(customers) : NotFound("customers not found!");
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var result = await _customerService.AddCustomerAsync(createCustomerDTO);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
