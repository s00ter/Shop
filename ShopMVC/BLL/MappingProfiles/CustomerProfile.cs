using AutoMapper;
using BLL.Dto;
using DAL.Entities;

namespace BLL.MappingProfiles;

internal class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}