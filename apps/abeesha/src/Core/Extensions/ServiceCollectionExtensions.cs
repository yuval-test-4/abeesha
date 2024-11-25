using Abeesha.APIs;

namespace Abeesha;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IOrdersService, OrdersService>();
    }
}
