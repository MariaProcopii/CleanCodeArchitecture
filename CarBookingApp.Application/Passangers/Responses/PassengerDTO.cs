using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Passangers.Responses;

public class PassengerDTO
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public static PassengerDTO FromPassenger(Passenger passenger)
    {
        return new PassengerDTO
        {
            Id = passenger.Id,
            Name = passenger.Name,
            Email = passenger.Email,
        };
    }
    
    public override string ToString()
    {
        return $"====Passenger Details====\n" +
               $"Passenger id: {Id}\n" +
               $"Passenger name: {Name}\n" +
               $"Passenger email: {Email}\n";
    }
}