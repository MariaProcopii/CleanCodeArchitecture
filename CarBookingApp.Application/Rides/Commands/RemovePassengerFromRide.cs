using CarBookingApp.Application.Abstractions;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record RemovePassengerFromRide(Guid RideId, Guid PassengerId) : IRequest<Guid>;

public class RemovePassengerFromRideHandler : IRequestHandler<RemovePassengerFromRide, Guid>
{
    private readonly IRideRepository _rideRepository;

    public RemovePassengerFromRideHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<Guid> Handle(RemovePassengerFromRide request, CancellationToken cancellationToken)
    {
        var removerdPassengerId = _rideRepository.RemovePassengerFromRide(request.RideId, request.PassengerId);
        return Task.FromResult(removerdPassengerId);
    }
}