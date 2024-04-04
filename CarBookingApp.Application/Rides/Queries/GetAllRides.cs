using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using MediatR;

namespace CarBookingApp.Application.Rides.Queries;

public record GetAllRides() : IRequest<List<RideDTO>>;

public class GetAllRidesHandler : IRequestHandler<GetAllRides, List<RideDTO >>
{
    private readonly IRideRepository _rideRepository;

    public GetAllRidesHandler(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    public Task<List<RideDTO>> Handle(GetAllRides request, CancellationToken cancellationToken)
    {
        var rides = _rideRepository.GetAll();
        return Task.FromResult(rides.Select(RideDTO.FromRide).ToList());
    }
}