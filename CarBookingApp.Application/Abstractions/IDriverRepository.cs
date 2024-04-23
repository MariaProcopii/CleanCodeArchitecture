using CarBoookingApp.Domain.Model;

namespace CarBookingApp.Application.Abstractions;

public interface IDriverRepository
{
    Task<Driver?> GetById(Guid id);
    Task<List<Driver>> GetAll();
    Task<Driver> Create(Driver driver);
    Task<Driver> Update(Driver driver);
    Task<Guid> Delete(Guid id);
}