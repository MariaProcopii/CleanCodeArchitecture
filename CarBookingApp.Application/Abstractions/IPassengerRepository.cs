using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IPassengerRepository
{
    Task<Passenger?> GetById(Guid id);
    Task<List<Passenger>> GetAll();
    Task<Passenger> Create(Passenger passenger);
    Task<Passenger> Update(Passenger passenger);
    Task<Guid> Delete(Guid id);
}