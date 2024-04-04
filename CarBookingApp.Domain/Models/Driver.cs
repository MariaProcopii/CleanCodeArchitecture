namespace CarBookingApp.Model;

public class Driver: User
{
    public List<Ride> CreatedRides { get; set; } = new List<Ride>();
    public required string CarModel { get; set; }
    public required string LicenseNumber { get; set; }
    

    public override void DisplayInfo()
    {
        Console.WriteLine( $"Driver id: {Id}\n"+
                           $"Driver name: {Name}\n" +
                           $"Driver email: {Email}\n" +
                           $"Car model: {CarModel}\n" +
                           $"License number: {LicenseNumber}");
    }
}