using CarBookingApp.Application.Abstractions;
using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Infrastructure;

public class DriverRepository : IDriverRepository
{
    private readonly List<Driver> _drivers = [];
    public Driver? GetById(Guid id)
    {
        return _drivers.FirstOrDefault(driver => driver.Id == id);
    }

    public List<Driver> GetAll()
    {
        return _drivers;
    }

    public Driver Create(Driver driver)
    {
        _drivers.Add(driver);
        return driver;
    }

    public Driver Update(Guid id, Driver driver)
    {
        var driverToUpdate = GetById(id);
        var index = _drivers.IndexOf(driverToUpdate);
        _drivers[index] = driver;
        return driver;
    }

    public Guid Delete(Guid id)
    {
        var driverToDelete = GetById(id);
        _drivers.Remove(driverToDelete);
        return id;
    }
}