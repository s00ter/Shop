using AutoMapper;
using BLL.Dto;
using BLL.Services.Abstractions;
using DAL.Entities;
using DAL.Repositories.Abstractions;

namespace BLL.Services.Implementations;

public class OrderService : ServiceBase<IOrderRepository, int, OrderDto, Order>, IOrderService
{
    public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}