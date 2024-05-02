using System.Reflection;
using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarBookingApp.Infrastructure.Configurations;

public class CarBookingAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Driver> Drivers { get; set; } = default!;
    public DbSet<Passenger> Passengers { get; set; } = default!;
    public DbSet<Ride> Rides { get; set; } = default!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = default!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = default!;

    public CarBookingAppDbContext()
    {
    }
    
    public CarBookingAppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}