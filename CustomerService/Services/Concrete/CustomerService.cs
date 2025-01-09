using AutoMapper;
using CustomerService.Data.Abstract;
using CustomerService.DTOs;
using CustomerService.Models;
using CustomerService.Services.Abstract;
using CustomerService.Utilities.Concrete;
using FluentValidation;

namespace CustomerService.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Customer> _validator;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IValidator<Customer> validator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result> AddCustomerAsync(CreateCustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            var validationResult = _validator.Validate(customerEntity);

            if (!validationResult.IsValid)
            {
                return Result.ValidationFailure(validationResult);
            }
            await _customerRepository.AddCustomerAsync(customerEntity);
            return Result.Success("Customer added successfully");
        }

        public async Task<Result> DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return Result.Success("Customer deleted successfully");
        }

        public async Task<CustomerDTO> GetCustomerAsync(int id)
        {
            var customerEntity= await _customerRepository.GetCustomerAsync(id);
            var customer= _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            var customersDTO=_mapper.Map<ICollection<CustomerDTO>>(customers);
            return customersDTO;
        }

        public async Task<Result> UpdateCustomerAsync(CreateCustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            var validationResult = _validator.Validate(customerEntity);

            if (!validationResult.IsValid)
            {
                return Result.ValidationFailure(validationResult);
            }
            await _customerRepository.UpdateCustomerAsync(customerEntity);
            return Result.Success("Customer updated successfully");
        }
    }
}
