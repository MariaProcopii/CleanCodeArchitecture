using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using MediatR;

namespace CarBookingApp.Application.Passangers.Queries;

public record GetAllPassengers() : IRequest<List<PassengerDTO>>;

public class GetAllPassengersHandler : IRequestHandler<GetAllPassengers, List<PassengerDTO>>
{
    private readonly IPassengerRepository _passengerRepository;

    public GetAllPassengersHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Task<List<PassengerDTO>> Handle(GetAllPassengers request, CancellationToken cancellationToken)
    {
        var passengers = _passengerRepository.GetAll();
        return Task.FromResult(passengers.Select(PassengerDTO.fromPassenger).ToList());
    }
}