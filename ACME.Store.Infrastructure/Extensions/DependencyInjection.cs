using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Infrastructure.Configurations;
using ACME.Store.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ACME.Store.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureConfigurations(this IServiceCollection services)
    {
        services.AddDbContext<StoreContext>();

        services.AddScoped<StoreContext, StoreContext>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IAddressRepository, AddressRepository>();

        return services;
    }
}
