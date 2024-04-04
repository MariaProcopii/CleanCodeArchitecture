using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record CreateRide(Guid OwnerId, string DestinationFrom, string DestinationTo, DateTime DateOfTheRide, int AvailableSeats) 
    : IRequest<RideDTO>;

public class CreateRideHandler : IRequestHandler<CreateRide, RideDTO>
{
    private readonly IRideRepository _rideRepository;
    private readonly IDriverRepository _driverRepository;

    public CreateRideHandler(IRideRepository rideRepository, IDriverRepository driverRepository)
    {
        _rideRepository = rideRepository;
        _driverRepository = driverRepository;
    }

    public Task<RideDTO> Handle(CreateRide request, CancellationToken cancellationToken)
    {
        var owner = _driverRepository.GetById(request.OwnerId);
        var ride = new Ride
        {
            Id = Guid.NewGuid(),
            DateOfTheRide = request.DateOfTheRide,
            DestinationFrom = request.DestinationFrom,
            DestinationTo = request.DestinationTo,
            AvailableSeats = request.AvailableSeats,
            Owner = owner
        };
        var createdRide = _rideRepository.Create(ride);
        return Task.FromResult(RideDTO.FromRide(createdRide));
    }
}