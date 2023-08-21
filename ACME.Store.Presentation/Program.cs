using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Extensions;
using ACME.Store.Domain.Middlewares;
using ACME.Store.Infrastructure.Configurations;
using ACME.Store.Infrastructure.Extensions;
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

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddSwaggerGen();
        }

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDomainConfigurations();

        builder.Services.AddInfrastructureConfigurations();

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
            var dataContext = scope.ServiceProvider.GetRequiredService<StoreContext>();

            dataContext.Database.Migrate();
        }

        app.Run();
    }
}
