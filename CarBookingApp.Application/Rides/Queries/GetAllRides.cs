using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Rides.Responses;
using MediatR;

namespace CarBookingApp.Application.Rides.Queries;

public record GetAllRides() : IRequest<List<RideDTO>>;

public class GetAllRidesHandler : IRequestHandler<GetAllRides, List<RideDTO >>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRidesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RideDTO>> Handle(GetAllRides request, CancellationToken cancellationToken)
    {
        var rides = await _unitOfWork.RideRepository.GetAll();
        return rides.Select(RideDTO.FromRide).ToList();
    }
}