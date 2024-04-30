using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure;
using CarBookingApp.Infrastructure.Configurations;
using CarBookingApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<CarBookingAppDbContext>()
    .AddSingleton<IDriverRepository, DriverRepository>()
    .AddSingleton<IPassengerRepository, PassengerRepository>()
    .AddSingleton<IRideRepository, RideRepository>()
    .AddSingleton<IUnitOfWork, UnitOfWork>()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IRideRepository).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();