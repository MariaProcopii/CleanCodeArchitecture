namespace CarBoookingApp.Domain.Model;

public class Driver : User
{ 
    public List<Ride> CreatedRides { get; set; }
    public required string LicenseNumber { get; set; }
    public VehicleType VehicleType { get; set; }
}