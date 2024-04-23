using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IRideRepository
{
    Task<Ride?> GetById(Guid id);
    Task<List<Ride>> GetAll();
    Task<Ride> Create(Ride ride);
    Task<Ride> Update(Ride ride);
    Task<Guid> BookRide(Guid rideId, Guid passengerId);
    Task<Guid> RemovePassengerFromRide(Guid rideId, Guid passengerId);
    Task<Guid> Delete(Guid id);
    
}