namespace CarBookingApp.PresentationWeb.Middlewares;

public class TimingMiddleware
{
    private readonly ILogger<TimingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public TimingMiddleware(ILogger<TimingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestReceiveTime = DateTime.UtcNow;
        await _next.Invoke(context);
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}. Time for processing: " +
                               $"{DateTime.UtcNow - requestReceiveTime} ms.");
    }
}