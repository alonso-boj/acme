using ACME.Store.Domain.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace ACME.Store.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainConfigurations(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }
}
