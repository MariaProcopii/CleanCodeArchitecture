namespace CarBoookingApp.Domain.Model;

public class Passenger
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public List<Ride> BookRides { get; set; } = [];
    public required string PaymentMethod { get; set; }
    
}