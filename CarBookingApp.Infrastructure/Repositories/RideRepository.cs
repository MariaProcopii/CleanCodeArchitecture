using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure.Configurations;
using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Infrastructure.Repositories;

public class RideRepository : IRideRepository
{
    private readonly CarBookingAppDbContext _carBookingAppDbContext;
    private readonly IPassengerRepository _passengerRepository;

    public RideRepository(CarBookingAppDbContext carBookingAppDbContext, IPassengerRepository passengerRepository)
    {
        _carBookingAppDbContext = carBookingAppDbContext;
        _passengerRepository = passengerRepository;
    }


    public async Task<Ride?> GetById(Guid id)
    {
        return await _carBookingAppDbContext.Rides
            .FirstOrDefaultAsync(ride => ride.Id == id);
    }

    public async Task <List<Ride>> GetAll()
    {
        return await _carBookingAppDbContext.Rides.ToListAsync();
    }

    public async Task<Ride> Create(Ride ride)
    {
        await _carBookingAppDbContext.Rides.AddAsync(ride);
        return ride;
    }

    public async Task<Ride> Update(Ride ride)
    {
        _carBookingAppDbContext.Rides.Update(ride);
        return ride;
    }

    public async Task<Guid> BookRide(Guid rideId, Guid passengerId)
    {
        var passenger = await _passengerRepository.GetById(passengerId);
        var rideToBook = await GetById(rideId);
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

    public async Task<Guid> RemovePassengerFromRide(Guid rideId, Guid passengerId)
    {
        var passenger = await _passengerRepository.GetById(passengerId);
        var ride = await GetById(rideId);
        passenger.BookRides.Remove(ride);
        ride.Passengers.Remove(passenger);
        ride.AvailableSeats++;
        return passenger.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var rideToDelete = await GetById(id);
        _carBookingAppDbContext.Rides.Remove(rideToDelete);
        return id;
    }
}
