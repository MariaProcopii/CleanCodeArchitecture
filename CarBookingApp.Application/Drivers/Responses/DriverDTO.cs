using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Drivers.Responses;

public class DriverDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<RideDTO> CreatedRides { get; set; } = [];
    public string CarModel { get; set; }
    public string LicenseNumber { get; set; }

    public static DriverDTO FromDriver(Driver driver)
    {
        return new DriverDTO
        {
            Id = driver.Id,
            Name = driver.Name,
            Email = driver.Email,
            CarModel = driver.CarModel,
            LicenseNumber = driver.LicenseNumber,
            CreatedRides = driver.CreatedRides.Select(RideDTO.FromRide).ToList()
        };
    }

    public override string ToString()
    {
        return $"====Driver Details====\n" +
               $"Driver id: {Id}\n" +
               $"Driver name: {Name}\n" +
               $"Driver email: {Email}\n" +
               $"Car model: {CarModel}\n" +
               $"License number: {LicenseNumber}\n" +
               $"Created Rides: {string.Join(", ", CreatedRides)}\n";
    }
}