using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record DeleteRide(Guid RideId) : IRequest<Guid>;

public class DeleteRideHandler : IRequestHandler<DeleteRide, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRideHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(DeleteRide request, CancellationToken cancellationToken)
    {
        var deletedDriverId = await _unitOfWork.RideRepository.Delete(request.RideId);
        await _unitOfWork.Save();
        return deletedDriverId;
    }
}