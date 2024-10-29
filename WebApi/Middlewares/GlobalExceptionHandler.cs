using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var details = new ProblemDetails()
        {
            Title = exception.Message,
            Detail = "API Error",
            Instance = $"API {httpContext.GetEndpoint}",
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "",
        };

        //var response = JsonSerializer.Serialize(details);
        //await httpContext.Response.WriteAsync(response, cancellationToken);

        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

        return true;
    }
}
