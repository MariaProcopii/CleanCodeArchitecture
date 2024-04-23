using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record DeleteDriver(Guid DriverId) : IRequest<Guid>;

public class DeleteDriverHandler : IRequestHandler<DeleteDriver, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDriverHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeleteDriver request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DriverRepository.Delete(request.DriverId);
        await _unitOfWork.Save();
        return request.DriverId;
    }
}
