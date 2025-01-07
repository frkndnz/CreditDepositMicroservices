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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersById(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            return customer != null ? Ok(customer) : NotFound("customer not found!");
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var result = await _customerService.AddCustomerAsync(createCustomerDTO);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var result = await _customerService.UpdateCustomerAsync(createCustomerDTO);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
