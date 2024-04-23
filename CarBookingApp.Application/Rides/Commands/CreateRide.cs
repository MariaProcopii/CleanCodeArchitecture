using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record CreateRide(Guid OwnerId, string DestinationFrom, string DestinationTo, DateTime DateOfTheRide, int AvailableSeats) 
    : IRequest<RideDTO>;

public class CreateRideHandler : IRequestHandler<CreateRide, RideDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRideHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RideDTO> Handle(CreateRide request, CancellationToken cancellationToken)
    {
        var owner = await _unitOfWork.DriverRepository.GetById(request.OwnerId);
        var ride = new Ride
        {
            DateOfTheRide = request.DateOfTheRide,
            DestinationFrom = request.DestinationFrom,
            DestinationTo = request.DestinationTo,
            AvailableSeats = request.AvailableSeats,
            Owner = owner
        };
        var createdRide = await _unitOfWork.RideRepository.Create(ride);
        await _unitOfWork.Save();
        return RideDTO.FromRide(createdRide);
    }
}