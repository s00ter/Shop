using AutoMapper;
using BLL.Dto;
using BLL.Services.Abstractions;
using DAL.Entities;
using DAL.Repositories.Abstractions;

namespace BLL.Services.Implementations;

public class ShopService : ServiceBase<IShopRepository, int, ShopDto, Shop>, IShopService
{
    public ShopService(IShopRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}