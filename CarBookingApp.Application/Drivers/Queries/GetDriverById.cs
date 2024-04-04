using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using MediatR;

namespace CarBookingApp.Application.Drivers.Queries;

public record GetDriverById(Guid DriverId) : IRequest<DriverDTO>;

public class GetDriverByIdHandler : IRequestHandler<GetDriverById, DriverDTO>
{
    private readonly IDriverRepository _driverRepository;

    public GetDriverByIdHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public Task<DriverDTO> Handle(GetDriverById request, CancellationToken cancellationToken)
    {
        var driver = _driverRepository.GetById(request.DriverId);
        return Task.FromResult(DriverDTO.FromDriver(driver));
    }
}