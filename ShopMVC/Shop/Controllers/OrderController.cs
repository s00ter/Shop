using BLL.Dto;
using BLL.Services.Abstractions;

namespace Shop.Controllers;

public class OrderController : ControllerBase<OrderDto, int, IOrderService>
{
    public OrderController(IOrderService service) : base(service)
    {
    }
}