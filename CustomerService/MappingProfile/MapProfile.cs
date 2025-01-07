using AutoMapper;
using CustomerService.DTOs;
using CustomerService.Models;
namespace CustomerService.MappingProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CreateCustomerDTO, Customer>();
        }
    }
}
