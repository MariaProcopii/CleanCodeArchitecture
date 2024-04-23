using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Drivers.Responses;

public class DriverDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }

    public static DriverDTO FromDriver(Driver driver)
    {
        return new DriverDTO
        {
            Id = driver.Id,
            Name = driver.Name,
            Email = driver.Email,
            LicenseNumber = driver.LicenseNumber
        };
    }

    public override string ToString()
    {
        return $"====Driver Details====\n" +
               $"Driver id: {Id}\n" +
               $"Driver name: {Name}\n" +
               $"Driver email: {Email}\n" +
               $"License number: {LicenseNumber}\n";
        
    }
}