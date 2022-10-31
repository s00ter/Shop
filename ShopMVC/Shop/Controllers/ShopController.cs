using BLL.Dto;
using BLL.Services.Abstractions;

namespace Shop.Controllers;

public class ShopController : ControllerBase<ShopDto, int, IShopService>
{
    public ShopController(IShopService service) : base(service)
    {
    }
}