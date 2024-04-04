namespace CarBookingApp.Model;

public class Passenger: User
{
    public List<Ride> BookRides { get; set; } = new List<Ride>();
    public required string PaymentMethod { get; set; }
    
    public override void DisplayInfo()
    {
        Console.WriteLine( $"Passenger id: {Id}\n"+
                           $"Passenger name: {Name}\n" +
                           $"Passenger email: {Email}\n" +
                           $"PaymentMethod: {PaymentMethod}");
    }
}