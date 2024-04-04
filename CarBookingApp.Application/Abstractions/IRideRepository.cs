using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IRideRepository
{
    Ride? GetById(Guid id);
    List<Ride> GetAll();
    Ride Create(Ride ride);
    Ride Update(Guid id, Ride ride);
    Guid BookRide(Guid rideId, Guid passengerId);
    Guid RemovePassengerFromRide(Guid rideId, Guid passengerId);
    Guid Delete(Guid id);
    
}