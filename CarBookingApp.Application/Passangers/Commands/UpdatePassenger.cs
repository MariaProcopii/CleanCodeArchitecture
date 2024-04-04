using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record UpdatePassenger(Guid PassengerId, Passenger UpdatedPassenger) : IRequest<PassengerDTO>;

public class UpdatePassengerHandler : IRequestHandler<UpdatePassenger, PassengerDTO>
{
    private readonly IPassengerRepository _passengerRepository;

    public UpdatePassengerHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Task<PassengerDTO> Handle(UpdatePassenger request, CancellationToken cancellationToken)
    {
        var newPassenger = _passengerRepository.Update(request.PassengerId, request.UpdatedPassenger);
        return Task.FromResult(PassengerDTO.fromPassenger(newPassenger));
    }
}