using BLL.Dto;
using BLL.Services.Abstractions;

namespace Shop.Controllers;

public class CustomerController : ControllerBase<CustomerDto, int, ICustomerService>
{
    public CustomerController(ICustomerService service) : base(service)
    {
    }
}