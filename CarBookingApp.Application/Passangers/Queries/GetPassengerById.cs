using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using MediatR;

namespace CarBookingApp.Application.Passangers.Queries;

public record GetPassengerById(Guid PassengerId) : IRequest<PassengerDTO>;

public class GetPassengerByIdHandler : IRequestHandler<GetPassengerById, PassengerDTO>
{
    private readonly IPassengerRepository _passengerRepository;

    public GetPassengerByIdHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Task<PassengerDTO> Handle(GetPassengerById request, CancellationToken cancellationToken)
    {
        var passenger = _passengerRepository.GetById(request.PassengerId);
        return Task.FromResult(PassengerDTO.fromPassenger(passenger));
    }
}
