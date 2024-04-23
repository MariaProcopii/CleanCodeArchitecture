using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record CreateDriver(string Name, string Email, string LicenseNumber) : IRequest<DriverDTO>;

public class CreateDriverHandler : IRequestHandler<CreateDriver, DriverDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDriverHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DriverDTO> Handle(CreateDriver request, CancellationToken cancellationToken)
    {
        var driver = new Driver
        {
            Name = request.Name,
            Email = request.Email,
            LicenseNumber = request.LicenseNumber
        };
        await _unitOfWork.DriverRepository.Create(driver);
        await _unitOfWork.Save();

        return DriverDTO.FromDriver(driver);
    }
}