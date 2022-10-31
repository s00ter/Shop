using Core;
using DAL.Repositories.Abstractions;
using DAL.Repositories.Implimentations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions;

public static class RepositoriesConfiguration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShopContext>(options => options
            .UseSqlite(configuration.GetConnectionString(DatabaseConstants.ConnectionStringName))
        );
        services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ShopContext>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IShopRepository, ShopRepository>();

        return services;
    }
}