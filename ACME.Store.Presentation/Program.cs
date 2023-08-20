using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ACME.Store.Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDomainConfigurations();

        builder.Services.AddApplicationConfigurations();

        var app = builder.Build();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
