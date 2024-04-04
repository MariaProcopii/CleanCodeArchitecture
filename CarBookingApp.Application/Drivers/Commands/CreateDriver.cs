using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record CreateDriver(string Name, string Email, string CarModel, string LicenseNumber) : IRequest<DriverDTO>;

public class CreateDriverHandler : IRequestHandler<CreateDriver, DriverDTO>
{
    private readonly IDriverRepository _driverRepository;

    public CreateDriverHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public Task<DriverDTO> Handle(CreateDriver request, CancellationToken cancellationToken)
    {
        var driver = new Driver
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            CarModel = request.CarModel,
            LicenseNumber = request.LicenseNumber
        };
        var createdDriver = _driverRepository.Create(driver);

        return Task.FromResult(DriverDTO.FromDriver(createdDriver));
    }
}