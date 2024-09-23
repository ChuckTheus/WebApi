namespace WebApi
{
    public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

        if (context.Request.Body.CanSeek)
        {
            context.Request.Body.Position = 0;
            using (var reader = new StreamReader(context.Request.Body))
            {
                var requestBody = await reader.ReadToEndAsync();
                _logger.LogInformation($"Request Body: {requestBody}");
                context.Request.Body.Position = 0;
            }
        }

        try
        {
            await _next(context);

            _logger.LogInformation($"Response Status: {context.Response.StatusCode}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            throw;
        }
    }
}

}
