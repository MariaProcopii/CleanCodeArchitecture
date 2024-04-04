using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record DeleteRide(Guid RideId) : IRequest<Guid>;

public class DeleteRideHandler : IRequestHandler<DeleteRide, Guid>
{
    private readonly IRideRepository _rideRepository;

    public DeleteRideHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<Guid> Handle(DeleteRide request, CancellationToken cancellationToken)
    {
        var rideToDelete = _rideRepository.GetById(request.RideId);
        rideToDelete.Owner.CreatedRides.Remove(rideToDelete);
        var ridePassengers = rideToDelete.Passengers;

        foreach (var passenger in ridePassengers)
        {
            _rideRepository.RemovePassengerFromRide(request.RideId, passenger.Id);
        }

        var deletedDriverId = _rideRepository.Delete(request.RideId);
        return Task.FromResult(deletedDriverId);
    }
}