using System.Collections;

namespace AmdarisAssignment3.Model;

public class Ride : Entity, ICloneable, IEnumerable<User>
{
    public required string DestinationFrom { get; set; }
    public required string DestinationTo { get; set; }
    public required int AvailableSeats { get; set; }
    public required User Owner { get; set; }
    public List<User> Passengers { get; set; } = new List<User>();
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public IEnumerator<User> GetEnumerator()
    {
        return Passengers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public override string ToString()
    {
        return $"====Ride Details====\n" +
               $"Destination: {DestinationFrom} to {DestinationTo}\n" +
               $"Available Seats: {AvailableSeats}\n" +
               $"Owner: {Owner.Name}\n" +
               $"Passengers: {string.Join(", ", Passengers)}\n";
    }
}
