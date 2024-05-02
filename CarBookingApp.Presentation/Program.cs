using CarBookingApp.Infrastructure.Configurations;
using CarBookingApp.PresentationWeb.Middlewares.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarBookingAppDbContext>(cfg =>
    cfg.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDB")));
builder.Services.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseTimingLogging();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();