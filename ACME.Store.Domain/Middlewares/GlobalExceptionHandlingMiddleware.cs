using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    private readonly IHostingEnvironment _environment;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger,
        IHostingEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, $"[{DateTime.UtcNow}] - An exception occurred: {ex.Message}");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ProblemDetails problemDetails = new()
            {
                Type = $"https://httpstatuses.com/{StatusCodes.Status500InternalServerError}",
                Title = ex.Message,
                Detail = "See the logs for more information",
                Instance = context.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
            };

            if (_environment.IsDevelopment())
            {
                problemDetails.Extensions.Add("stackTrace", ex.StackTrace);
            }

            string json = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
