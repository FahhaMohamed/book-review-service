public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"[Request] {context.Request.Method}: {context.Request.Path}");
        _logger.LogInformation($"[Response] StatusCode: {context.Response.StatusCode}");
        await _next(context);
    }
}