using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Responses;
using MediatR;

namespace CarBookingApp.Application.Drivers.Queries;

public record GetDriverById(Guid DriverId) : IRequest<DriverDTO>;

public class GetDriverByIdHandler : IRequestHandler<GetDriverById, DriverDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDriverByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DriverDTO> Handle(GetDriverById request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.DriverRepository.GetById(request.DriverId);
        return DriverDTO.FromDriver(driver);
    }
}