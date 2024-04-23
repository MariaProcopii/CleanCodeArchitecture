using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Passangers.Responses;
using MediatR;

namespace CarBookingApp.Application.Passangers.Queries;

public record GetPassengerById(Guid PassengerId) : IRequest<PassengerDTO>;

public class GetPassengerByIdHandler : IRequestHandler<GetPassengerById, PassengerDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPassengerByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PassengerDTO> Handle(GetPassengerById request, CancellationToken cancellationToken)
    {
        var passenger = await _unitOfWork.PassengerRepository.GetById(request.PassengerId);
        return PassengerDTO.FromPassenger(passenger);
    }
}
