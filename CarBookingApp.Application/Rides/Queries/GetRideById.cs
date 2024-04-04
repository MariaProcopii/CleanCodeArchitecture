using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using MediatR;

namespace CarBookingApp.Application.Rides.Queries;

public record GetRideById(Guid RideId) : IRequest<RideDTO>;

public class GetRideByIdHandler : IRequestHandler<GetRideById, RideDTO>
{
    private readonly IRideRepository _rideRepository;

    public GetRideByIdHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<RideDTO> Handle(GetRideById request, CancellationToken cancellationToken)
    {
        var ride = _rideRepository.GetById(request.RideId);
        return Task.FromResult(RideDTO.FromRide(ride));
    }
}