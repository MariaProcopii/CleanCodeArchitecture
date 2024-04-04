using System.Collections;

namespace CarBoookingApp.Domain.Model;

public class Ride
{
    public required Guid Id { get; init; }
    public required DateTime DateOfTheRide { get; set; }
    public required string DestinationFrom { get; set; }
    public required string DestinationTo { get; set; }
    public required int AvailableSeats { get; set; }
    public required Driver Owner { get; set; }
    public List<Passenger> Passengers { get; set; } = [];
}
