using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure.Configurations;
using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Infrastructure.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private readonly CarBookingAppDbContext _carBookingAppDbContext;
    public PassengerRepository(CarBookingAppDbContext carBookingAppDbContext)
    {
        _carBookingAppDbContext = carBookingAppDbContext;
    }

    public async Task<Passenger?> GetById(Guid id)
    {
        return  await _carBookingAppDbContext.Passengers
            .Include(p => p.BookRides)
            .Include(p => p.PaymentMethods)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Passenger>> GetAll()
    {
        return await _carBookingAppDbContext.Passengers.ToListAsync();
    }
    
    public async Task<Passenger> Create(Passenger passenger)
    {
        await _carBookingAppDbContext.Passengers.AddAsync(passenger);
        return passenger;
    }

    public async Task<Passenger> Update(Passenger passenger)
    {
        _carBookingAppDbContext.Update(passenger);
        return passenger;
    }
    
    public async Task<Guid> Delete(Guid id)
    {
        var passengerToDelete = await GetById(id);
        if (passengerToDelete != null)
        {
            _carBookingAppDbContext.Passengers.Remove(passengerToDelete);
        }
        return id;
    }
}