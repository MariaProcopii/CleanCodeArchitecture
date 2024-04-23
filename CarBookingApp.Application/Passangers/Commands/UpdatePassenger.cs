using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record UpdatePassenger(PassengerDTO UpdatedPassenger) : IRequest<PassengerDTO>;

public class UpdatePassengerHandler : IRequestHandler<UpdatePassenger, PassengerDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePassengerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PassengerDTO> Handle(UpdatePassenger request, CancellationToken cancellationToken)
    {
        var passenger = _unitOfWork.PassengerRepository.GetById(request.UpdatedPassenger.Id).Result;
        if (passenger != null)
        {
            passenger.Email = request.UpdatedPassenger.Email;
            passenger.Name = request.UpdatedPassenger.Name;
        }

        await _unitOfWork.PassengerRepository.Update(passenger);
        await _unitOfWork.Save();
        return request.UpdatedPassenger;
    }
}