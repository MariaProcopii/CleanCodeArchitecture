using CarBookingApp.Application.Abstractions;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Infrastructure;

public class RideRepository : IRideRepository
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly List<Ride> _rides = [];

    public RideRepository(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Ride? GetById(Guid id)
    {
        return _rides.FirstOrDefault(ride => ride.Id == id);
    }

    public List<Ride> GetAll()
    {
        return _rides;
    }

    public Ride Create(Ride ride)
    {
        _rides.Add(ride);
        return ride;
    }

    public Ride Update(Guid id, Ride ride)
    {
        var rideToUpdate = GetById(id);
        var index = _rides.IndexOf(rideToUpdate);
        _rides[index] = ride;
        return ride;
    }

    public Guid BookRide(Guid rideId, Guid passengerId)
    {
        var passenger = _passengerRepository.GetById(passengerId);
        var rideToBook = GetById(rideId);
        if (rideToBook.AvailableSeats > 0)
        {
            passenger.BookRides.Add(rideToBook);
            rideToBook.Passengers.Add(passenger);
            rideToBook.AvailableSeats--;
            Console.WriteLine($"Ride {rideToBook.Id} was booked by {passenger.Name}");
        }
        else
        {
            Console.WriteLine($"No available seats for ride {rideToBook.Id}");
        }

        return rideId;
    }

    public Guid RemovePassengerFromRide(Guid rideId, Guid passengerId)
    {
        var passenger = _passengerRepository.GetById(passengerId);
        var ride = GetById(rideId);
        passenger.BookRides.Remove(ride);
        ride.Passengers.Remove(passenger);
        return passenger.Id;
    }

    public Guid Delete(Guid id)
    {
        var rideToDelete = GetById(id);
        _rides.Remove(rideToDelete);
        return id;
    }
}
