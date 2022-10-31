using DAL.Extensions;
using BLL.Extensions;

namespace Shop.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .ConfigureRepositories(configuration)
            .ConfigureServices();
    }
}