using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using CarBookingApp.Application.Rides.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record UpdateRide(RideDTO UpdatedRide) : IRequest<RideDTO>;

public class UpdateRideHandler : IRequestHandler<UpdateRide, RideDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRideHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RideDTO> Handle(UpdateRide request, CancellationToken cancellationToken)
    {
        var ride = await _unitOfWork.RideRepository.GetById(request.UpdatedRide.Id);
        if (ride != null)
        {
            ride.DateOfTheRide = request.UpdatedRide.DateOfTheRide;
            ride.AvailableSeats = request.UpdatedRide.AvailableSeats;
            ride.DestinationFrom = request.UpdatedRide.DestinationFrom;
            ride.DestinationTo = request.UpdatedRide.DestinationTo;
        }

        var newRide = await _unitOfWork.RideRepository.Update(ride);
        await _unitOfWork.Save();
        return RideDTO.FromRide(newRide);
    }
}