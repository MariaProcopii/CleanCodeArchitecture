namespace CarBoookingApp.Domain.Model;

public class Passenger : User
{
    public List<Ride> BookRides { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = [];
}