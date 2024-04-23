using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBookingApp.Infrastructure.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder
            .Property(d => d.Email)
            .HasMaxLength(50);
        
        builder
            .HasIndex(d => d.Email)
            .IsUnique();

        builder
            .HasOne(d => d.VehicleType)
            .WithOne()
            .HasForeignKey<VehicleType>(vt => vt.Id);

        builder
            .Property(d => d.Name)
            .HasMaxLength(30);

        builder
            .Property(d => d.LicenseNumber)
            .HasMaxLength(50);
    }
}