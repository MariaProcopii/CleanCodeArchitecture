using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Passangers.Commands;

public record DeletePassenger(Guid PassengerId) : IRequest<Guid>;

public class DeletePassengerHandler : IRequestHandler<DeletePassenger, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePassengerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeletePassenger request, CancellationToken cancellationToken)
    {
        await _unitOfWork.PassengerRepository.Delete(request.PassengerId);
        await _unitOfWork.Save();
        return request.PassengerId;
    }
}
