using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IDriverRepository
{
    Driver? GetById(Guid id);
    List<Driver> GetAll();
    Driver Create(Driver driver);
    Driver Update(Guid id, Driver driver);
    Guid Delete(Guid id);
}