using CarBookingApp.Application.Drivers.Responses;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Rides.Responses;

public class RideDTO
{
    public Guid Id { get; set; }
    public required DateTime DateOfTheRide { get; set; }
    public string DestinationFrom { get; set; }
    public string DestinationTo { get; set; }
    public int AvailableSeats { get; set; }
    public DriverDTO Owner { get; set; }

    public static RideDTO FromRide(Ride ride)
    {
        return new RideDTO
        {
            Id = ride.Id,
            DateOfTheRide = ride.DateOfTheRide,
            DestinationFrom = ride.DestinationFrom,
            DestinationTo = ride.DestinationTo,
            AvailableSeats = ride.AvailableSeats,
            Owner = DriverDTO.FromDriver(ride.Owner)
        };
    }
    
    public override string ToString()
    {
        return $"====Ride Details====\n" +
               $"Destination: {DestinationFrom} to {DestinationTo}\n" +
               $"Available Seats: {AvailableSeats}\n" +
               $"Owner: {Owner.Name}\n";
    }
}