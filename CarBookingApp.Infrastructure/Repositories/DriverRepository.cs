using CarBookingApp.Application.Abstractions;
using CarBookingApp.Infrastructure.Configurations;
using CarBoookingApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Infrastructure.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly CarBookingAppDbContext _carBookingAppDbContext;

    public DriverRepository(CarBookingAppDbContext carBookingAppDbContext)
    {
        _carBookingAppDbContext = carBookingAppDbContext;
    }

    public async Task<Driver?> GetById(Guid id)
    {
        return await _carBookingAppDbContext.Drivers.Include(d => d.CreatedRides)
            .FirstOrDefaultAsync(driver => driver.Id == id);
    }

    public async Task<List<Driver>> GetAll()
    {
        return await _carBookingAppDbContext.Drivers.ToListAsync();
    }

    public async Task<Driver> Create(Driver driver)
    {
        await _carBookingAppDbContext.Drivers.AddAsync(driver);
        return driver;
    }

    public async Task<Driver> Update(Driver driver)
    {
        _carBookingAppDbContext.Drivers.Update(driver);
        return driver;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var driverToDelete = await GetById(id);
        if (driverToDelete != null)
        {
            _carBookingAppDbContext.Drivers.Remove(driverToDelete);
        }
        return id;
    }
}