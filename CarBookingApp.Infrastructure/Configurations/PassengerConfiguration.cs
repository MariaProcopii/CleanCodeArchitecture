using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBookingApp.Infrastructure.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder
            .Property(p => p.Email)
            .HasMaxLength(50);
        
        builder
            .HasIndex(p => p.Email)
            .IsUnique();

        builder
            .HasMany(p => p.BookRides)
            .WithMany(p => p.Passengers);

        builder
            .HasMany(p => p.PaymentMethods)
            .WithMany();
        
        builder
            .Property(p => p.Name)
            .HasMaxLength(30);
    }
}