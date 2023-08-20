using ACME.Store.Application.Validators;
using ACME.Store.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ACME.Store.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(RegisterCustomerRequestDtoValidator)));


        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}
