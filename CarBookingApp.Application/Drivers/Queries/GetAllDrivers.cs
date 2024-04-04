using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using MediatR;

namespace CarBookingApp.Application.Drivers.Queries;

public record GetAllDrivers() : IRequest<List<DriverDTO>>;

public class GetAllDriversHandler : IRequestHandler<GetAllDrivers, List<DriverDTO>>
{
    private readonly IDriverRepository _driverRepository;

    public GetAllDriversHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public Task<List<DriverDTO>> Handle(GetAllDrivers request, CancellationToken cancellationToken)
    {
        var drivers = _driverRepository.GetAll();
        return Task.FromResult(drivers.Select(DriverDTO.FromDriver).ToList());
    }
}