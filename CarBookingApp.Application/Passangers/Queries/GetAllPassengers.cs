using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using MediatR;

namespace CarBookingApp.Application.Passangers.Queries;

public record GetAllPassengers() : IRequest<List<PassengerDTO>>;

public class GetAllPassengersHandler : IRequestHandler<GetAllPassengers, List<PassengerDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPassengersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<PassengerDTO>> Handle(GetAllPassengers request, CancellationToken cancellationToken)
    {
        var passengers = await _unitOfWork.PassengerRepository.GetAll();
        return passengers.Select(PassengerDTO.FromPassenger).ToList();
    }
}