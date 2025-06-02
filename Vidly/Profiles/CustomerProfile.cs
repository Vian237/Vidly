using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
