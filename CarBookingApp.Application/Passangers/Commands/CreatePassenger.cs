using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record CreatePassenger(string Name, string Email, string PaymentMethod): IRequest<PassengerDTO>;

public class CreatePassengerHandler : IRequestHandler<CreatePassenger, PassengerDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePassengerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PassengerDTO> Handle(CreatePassenger request, CancellationToken cancellationToken)
    {
        
        var paymentMethod = new PaymentMethod
        {
            PaymentMethodName = request.PaymentMethod
        };
        var passenger = new Passenger
        {
            Name = request.Name,
            Email = request.Email
        };
        passenger.PaymentMethods.Add(paymentMethod);

        await _unitOfWork.PassengerRepository.Create(passenger);
        await _unitOfWork.Save();

        return PassengerDTO.FromPassenger(passenger);
    }
}