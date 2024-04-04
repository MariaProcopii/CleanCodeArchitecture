using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record CreatePassenger(string Name, string Email, string PaymentMethod): IRequest<PassengerDTO>;

public class CreatePassengerHandler : IRequestHandler<CreatePassenger, PassengerDTO>
{
    private readonly IPassengerRepository _passengerRepository;

    public CreatePassengerHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Task<PassengerDTO> Handle(CreatePassenger request, CancellationToken cancellationToken)
    {
        var passenger = new Passenger
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PaymentMethod = request.PaymentMethod
        };
        var createdPassenger = _passengerRepository.Create(passenger);
        
        return Task.FromResult(PassengerDTO.fromPassenger(createdPassenger));
    }
}