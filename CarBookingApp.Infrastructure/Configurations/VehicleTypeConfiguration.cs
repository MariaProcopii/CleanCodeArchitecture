using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBookingApp.Infrastructure.Configurations;

public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder
            .Property(vt => vt.CarModel)
            .HasMaxLength(50);
        builder
            .HasIndex(vt => new {vt.Id, vt.CarModel})
            .IsUnique();
    }
}