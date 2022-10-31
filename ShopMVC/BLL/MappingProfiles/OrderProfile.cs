using AutoMapper;
using BLL.Dto;
using DAL.Entities;

namespace BLL.MappingProfiles;

internal class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
    }
        
}