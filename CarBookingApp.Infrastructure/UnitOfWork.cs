using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private CarBookingAppDbContext _carBookingAppDbContext;

    public UnitOfWork(CarBookingAppDbContext carBookingAppDbContext, IDriverRepository driverRepository, 
        IPassengerRepository passengerRepository, IRideRepository rideRepository)
    {
        _carBookingAppDbContext = carBookingAppDbContext;
        DriverRepository = driverRepository;
        PassengerRepository = passengerRepository;
        RideRepository = rideRepository;
    }

    public IDriverRepository DriverRepository { get; private set; }
    public IPassengerRepository PassengerRepository { get; private set; }
    public IRideRepository RideRepository { get; private set; }
    
    
    public async Task Save()
    {
        await _carBookingAppDbContext.SaveChangesAsync();
    }

    public async Task BeginTransaction()
    {
        await _carBookingAppDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await _carBookingAppDbContext.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await _carBookingAppDbContext.Database.RollbackTransactionAsync();
    }
}