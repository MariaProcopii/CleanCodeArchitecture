namespace CarBoookingApp.Domain.Model;

public abstract class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}