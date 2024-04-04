using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record UpdateDriver(Guid driverId, Driver UpdatedDriver) : IRequest<DriverDTO>;

public class UpdateDriverHandler : IRequestHandler<UpdateDriver, DriverDTO>
{
    private readonly IDriverRepository _driverRepository;

    public UpdateDriverHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public Task<DriverDTO> Handle(UpdateDriver request, CancellationToken cancellationToken)
    {
        var newDriver = _driverRepository.Update(request.driverId, request.UpdatedDriver);
        return Task.FromResult(DriverDTO.FromDriver(newDriver));
    }
}