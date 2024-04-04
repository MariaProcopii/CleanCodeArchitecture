namespace CarBookingApp.Model;

public abstract class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }

    public abstract void DisplayInfo();
}