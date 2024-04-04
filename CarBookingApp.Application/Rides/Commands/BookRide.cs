using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record BookRide(Guid RideId, Guid PassengerId) : IRequest<Guid>;

public class BookRideHandler : IRequestHandler<BookRide, Guid>
{
    private readonly IRideRepository _rideRepository;

    public BookRideHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<Guid> Handle(BookRide request, CancellationToken cancellationToken)
    {
        var bookedRideId = _rideRepository.BookRide(request.RideId, request.PassengerId);
        return Task.FromResult(bookedRideId);
    }
}