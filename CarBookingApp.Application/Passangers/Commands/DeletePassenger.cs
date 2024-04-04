using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record DeletePassenger(Guid PassengerId) : IRequest<Guid>;

public class DeletePassengerHandler : IRequestHandler<DeletePassenger, Guid>
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly IRideRepository _rideRepository;

    public DeletePassengerHandler(IPassengerRepository passengerRepository, IRideRepository rideRepository)
    {
        _passengerRepository = passengerRepository;
        _rideRepository = rideRepository;
    }

    public Task<Guid> Handle(DeletePassenger request, CancellationToken cancellationToken)
    {
        var passengerToDelete = _passengerRepository.GetById(request.PassengerId);
        var bookedRideIds = passengerToDelete.BookRides.Select(ride => ride.Id).ToList();
        foreach (var rideId in bookedRideIds)
        {
            _rideRepository.RemovePassengerFromRide(rideId, request.PassengerId);
        }

        var deletedPassengerId = _passengerRepository.Delete(request.PassengerId);
        return Task.FromResult(deletedPassengerId);
    }
}
