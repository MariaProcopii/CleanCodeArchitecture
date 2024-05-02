using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure;
using CarBookingApp.Infrastructure.Repositories;

namespace CarBookingApp.PresentationWeb.Middlewares.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection svcs)
    {
        svcs
            .AddScoped<IDriverRepository, DriverRepository>()
            .AddScoped<IPassengerRepository, PassengerRepository>()
            .AddScoped<IRideRepository, RideRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IRideRepository).Assembly));
    }
}