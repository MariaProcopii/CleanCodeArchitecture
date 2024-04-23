namespace CarBookingApp.Application.Abstractions;

public interface IUnitOfWork
{
    public IDriverRepository DriverRepository { get; }
    public IPassengerRepository PassengerRepository { get; }
    public IRideRepository RideRepository { get; }

    Task Save();
    Task BeginTransaction();
    Task CommitTransaction();
    Task RollbackTransaction();
}