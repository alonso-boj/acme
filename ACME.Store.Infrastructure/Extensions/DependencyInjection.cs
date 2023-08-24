using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Infrastructure.Configurations;
using ACME.Store.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace ACME.Store.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureConfigurations(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        var connectionString = configuration.GetConnectionString("Local");

        services.AddDbContext<StoreContext>(cfg =>
        {
            cfg.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(isDevelopment is true)
                .EnableDetailedErrors(isDevelopment is true)
                .LogTo(Console.WriteLine);
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IAddressRepository, AddressRepository>();

        return services;
    }
}
