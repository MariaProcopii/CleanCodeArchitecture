using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record UpdateRide(Guid RideId, Ride UpdatedRide) : IRequest<RideDTO>;

public class UpdateRideHandler : IRequestHandler<UpdateRide, RideDTO>
{
    private readonly IRideRepository _rideRepository;

    public UpdateRideHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<RideDTO> Handle(UpdateRide request, CancellationToken cancellationToken)
    {
        var newRide = _rideRepository.Update(request.RideId, request.UpdatedRide);
        return Task.FromResult(RideDTO.FromRide(newRide));
    }
}