namespace CarBookingApp.PresentationWeb.Middlewares.Extensions;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseTimingLogging(this IApplicationBuilder app) 
        => app.UseMiddleware<TimingMiddleware>();
}