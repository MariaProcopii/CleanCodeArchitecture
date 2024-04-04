using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record DeleteDriver(Guid DriverId) : IRequest<Guid>;

public class DeleteDriverHandler : IRequestHandler<DeleteDriver, Guid>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IRideRepository _rideRepository;

    public DeleteDriverHandler(IDriverRepository driverRepository, IRideRepository rideRepository)
    {
        _driverRepository = driverRepository;
        _rideRepository = rideRepository;
    }

    public Task<Guid> Handle(DeleteDriver request, CancellationToken cancellationToken)
    {
        var driver = _driverRepository.GetById(request.DriverId);
        var driverRideIds = driver.CreatedRides.Select(ride => ride.Id).ToList();
        foreach (var rideId in driverRideIds)
        {
            _rideRepository.Delete(rideId);
        }

        var deletedDriverId = _driverRepository.Delete(request.DriverId);
        return Task.FromResult(deletedDriverId);
    }
}
