using CarBookingApp.Application.Abstractions;
using MediatR;

namespace CarBookingApp.Application.Rides.Commands;

public record BookRide(Guid RideId, Guid PassengerId) : IRequest<Guid>;

public class BookRideHandler : IRequestHandler<BookRide, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public BookRideHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(BookRide request, CancellationToken cancellationToken)
    {
        var bookedRideId = await _unitOfWork.RideRepository.BookRide(request.RideId, request.PassengerId);
        await _unitOfWork.Save();
        return bookedRideId;
    }
}