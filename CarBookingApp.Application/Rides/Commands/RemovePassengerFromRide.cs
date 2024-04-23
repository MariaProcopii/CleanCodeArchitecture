using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record RemovePassengerFromRide(Guid RideId, Guid PassengerId) : IRequest<Guid>;

public class RemovePassengerFromRideHandler : IRequestHandler<RemovePassengerFromRide, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePassengerFromRideHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemovePassengerFromRide request, CancellationToken cancellationToken)
    {
        var removedPassengerId = await _unitOfWork.RideRepository
            .RemovePassengerFromRide(request.RideId, request.PassengerId);
        await _unitOfWork.Save();
        return removedPassengerId;
    }
}