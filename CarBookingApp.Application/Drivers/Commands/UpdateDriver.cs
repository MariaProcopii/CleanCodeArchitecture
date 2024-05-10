using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;

namespace CarBookingApp.Application.Drivers.Commands;

public record UpdateDriver(DriverDTO UpdatedDriver) : IRequest<DriverDTO>;

public class UpdateDriverHandler : IRequestHandler<UpdateDriver, DriverDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDriverHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DriverDTO> Handle(UpdateDriver request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(request.UpdatedDriver.Id);
        if (driver != null)                                                 
        {
            driver.Email = request.UpdatedDriver.Email;
            driver.Name = request.UpdatedDriver.Name;
            driver.LicenseNumber = request.UpdatedDriver.LicenseNumber;
        }

        await _unitOfWork.DriverRepository.Update(driver);
        await _unitOfWork.Save();
        return request.UpdatedDriver;
    }
}