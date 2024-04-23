namespace CarBoookingApp.Domain.Model;

public class VehicleType
{
    public required Guid Id { get; init; }
    public required string CarModel { get; set; }
}