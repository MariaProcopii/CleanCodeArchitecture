using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using MediatR;

namespace CarBookingApp.Application.Rides.Queries;

public record GetRideById(Guid RideId) : IRequest<RideDTO>;

public class GetRideByIdHandler : IRequestHandler<GetRideById, RideDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRideByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RideDTO> Handle(GetRideById request, CancellationToken cancellationToken)
    {
        var ride = await _unitOfWork.RideRepository.GetById(request.RideId);
        return RideDTO.FromRide(ride);
    }
}