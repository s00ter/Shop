using BLL.Dto;
using BLL.Services.Abstractions;

namespace Shop.Controllers;

public class ProductController : ControllerBase<ProductDto, int, IProductService>
{
    public ProductController(IProductService service) : base(service)
    {
    }
}