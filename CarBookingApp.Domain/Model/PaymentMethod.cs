namespace CarBoookingApp.Domain.Model;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public required string PaymentMethodName { get; set; }
}