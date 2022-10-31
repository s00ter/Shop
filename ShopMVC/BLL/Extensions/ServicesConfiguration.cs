using System.Reflection;
using BLL.Services.Abstractions;
using BLL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        var assembly = typeof(ServicesConfiguration).GetTypeInfo().Assembly;

        serviceCollection.AddAutoMapper(assembly);
        
        serviceCollection.AddScoped<ICustomerService, CustomerService>();
        serviceCollection.AddScoped<IShopService, ShopService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();

        
        return serviceCollection;
    }
}