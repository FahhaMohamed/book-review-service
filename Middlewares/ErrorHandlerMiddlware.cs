using Newtonsoft.Json;

public class ErrorHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new
            {
                status = false,
                message = "Internal Server Error",
            };

            var toJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            await context.Response.WriteAsync(toJson);
        }
    }
}