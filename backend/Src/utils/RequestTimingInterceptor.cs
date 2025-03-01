using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging; 

public class RequestTimingInterceptor : IAsyncActionFilter
{
    private readonly ILogger<RequestTimingInterceptor> _logger;

    public RequestTimingInterceptor(ILogger<RequestTimingInterceptor> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();

        var resultContext = await next(); // Eksekusi action

        stopwatch.Stop();
        var elapsedMs = stopwatch.ElapsedMilliseconds;

        var method = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;
        var statusCode = resultContext.HttpContext.Response.StatusCode;

        _logger.LogInformation($"[{method}] {path} responded with {statusCode} in {elapsedMs}ms");
    }
}
