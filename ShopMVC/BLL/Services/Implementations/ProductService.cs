using AutoMapper;
using BLL.Dto;
using BLL.Services.Abstractions;
using DAL.Entities;
using DAL.Repositories.Abstractions;

namespace BLL.Services.Implementations;

public class ProductService : ServiceBase<IProductRepository, int, ProductDto, Product>, IProductService
{
    public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}