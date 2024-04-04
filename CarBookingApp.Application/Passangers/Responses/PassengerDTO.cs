using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Passangers.Responses;

public class PassengerDTO
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public List<RideDTO> BookRides { get; set; } = [];
    public required string PaymentMethod { get; set; }

    public static PassengerDTO fromPassenger(Passenger passenger)
    {
        return new PassengerDTO
        {
            Id = passenger.Id,
            Name = passenger.Name,
            Email = passenger.Email,
            PaymentMethod = passenger.PaymentMethod,
            BookRides = passenger.BookRides.Select(RideDTO.FromRide).ToList()
        };
    }
    
    public override string ToString()
    {
        return $"====Passenger Details====\n" +
               $"Passenger id: {Id}\n" +
               $"Passenger name: {Name}\n" +
               $"Passenger email: {Email}\n" +
               $"PaymentMethod: {PaymentMethod}\n" +
               $"Booked Rides: \n{string.Join(", ", BookRides)}\n";
    }
}