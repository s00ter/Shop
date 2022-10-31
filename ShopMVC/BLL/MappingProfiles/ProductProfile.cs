using AutoMapper;
using BLL.Dto;
using DAL.Entities;

namespace BLL.MappingProfiles;

internal class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}