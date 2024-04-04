using CarBookingApp.Application.Abstractions;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Infrastructure;

public class PassengerRepository : IPassengerRepository
{
    private readonly List<Passenger> _passengers = [];
    public Passenger? GetById(Guid id)
    {
        return _passengers.FirstOrDefault(passenger => passenger.Id.Equals(id));
    }

    public List<Passenger> GetAll()
    {
        return _passengers;
    }

    public Passenger Create(Passenger passenger)
    {
        _passengers.Add(passenger);
        return passenger;
    }

    public Passenger Update(Guid id, Passenger passenger)
    {
        var passangerToUpdate = GetById(id);
        var index = _passengers.IndexOf(passangerToUpdate);
        _passengers[index] = passenger;
        return passenger;
    }

    public Guid Delete(Guid id)
    {
        var passengerToDelete = GetById(id);
        _passengers.Remove(passengerToDelete);
        return id;
    }
}