using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBookingApp.Infrastructure.Configurations;

public class RideConfiguration : IEntityTypeConfiguration<Ride>
{
    public void Configure(EntityTypeBuilder<Ride> builder)
    {
        builder
            .HasOne(r => r.Owner)
            .WithMany(d => d.CreatedRides)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(r => r.DestinationFrom)
            .HasMaxLength(50);

        builder
            .Property(r => r.DestinationTo)
            .HasMaxLength(50);

        builder
            .Property(r => r.AvailableSeats)
            .HasColumnName("available_seats")
            .HasDefaultValue(1);

        builder.ToTable("Rides",
            t =>
            {
                t.HasCheckConstraint("CK_Ride_AvailableSeats", "available_seats >= 1 AND available_seats <= 6");
            });
    }  
}