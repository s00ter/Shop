using AutoMapper;
using BLL.Dto;
using DAL.Entities;

namespace BLL.MappingProfiles;

internal class ShopProfile : Profile
{
    public ShopProfile()
    {
        CreateMap<Shop, ShopDto>().ReverseMap();
    }
}