using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Extensions;
using ACME.Store.Domain.Middlewares;
using ACME.Store.Infrastructure.Configurations;
using ACME.Store.Infrastructure.Extensions;
using ACME.Store.Presentation.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ACME.Store.Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddSwaggerGenConfigurations();
        }

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDomainConfigurations();

        builder.Services.AddInfrastructureConfigurations(configuration, builder.Environment.IsDevelopment());

        builder.Services.AddApplicationConfigurations();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseDeveloperExceptionPage();
        }

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();

            context.Database.Migrate();
        }

        app.Run();
    }
}
