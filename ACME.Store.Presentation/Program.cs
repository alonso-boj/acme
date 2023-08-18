using ACME.Store.Application.Validators;
using ACME.Store.Domain.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ACME.Store.Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(RegisterCustomerRequestValidator)));

        builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

        var app = builder.Build();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
