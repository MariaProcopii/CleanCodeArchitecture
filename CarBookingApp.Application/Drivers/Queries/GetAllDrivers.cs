using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using MediatR;

namespace CarBookingApp.Application.Drivers.Queries;

public record GetAllDrivers() : IRequest<List<DriverDTO>>;

public class GetAllDriversHandler : IRequestHandler<GetAllDrivers, List<DriverDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDriversHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<DriverDTO>> Handle(GetAllDrivers request, CancellationToken cancellationToken)
    {
        var drivers = await _unitOfWork.DriverRepository.GetAll();
        return drivers.Select(DriverDTO.FromDriver).ToList();
    }
}