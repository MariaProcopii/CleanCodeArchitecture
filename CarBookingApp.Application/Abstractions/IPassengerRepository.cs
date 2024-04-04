using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IPassengerRepository
{
    Passenger? GetById(Guid id);
    List<Passenger> GetAll();
    Passenger Create(Passenger passenger);
    Passenger Update(Guid id, Passenger passenger);
    Guid Delete(Guid id);
}