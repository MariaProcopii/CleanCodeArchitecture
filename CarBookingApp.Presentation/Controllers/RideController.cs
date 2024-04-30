using CarBookingApp.Application.Rides.Commands;
using CarBookingApp.Application.Rides.Queries;
using CarBookingApp.Application.Rides.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingApp.PresentationWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class RideController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;

    private readonly IMediator _mediator;

    public RideController(ILogger<PassengerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<RideDTO> GetRideById(Guid id)
    {
        var result = await _mediator.Send(new GetRideById(id));
        return result;
    }
    
    [HttpGet]
    public async Task<List<RideDTO>> GetRides()
    {
        var result = await _mediator.Send(new GetAllRides());
        return result;
    }
    
    [HttpPost]
    [Route("{id}")]
    public async Task<RideDTO> CreateRide(Guid id, [FromBody] RideDTO ride)
    {
        var result = await _mediator.Send(new CreateRide(OwnerId: id,
            DestinationFrom: ride.DestinationFrom, DestinationTo: ride.DestinationTo, AvailableSeats: ride.AvailableSeats,
            DateOfTheRide: ride.DateOfTheRide));
        return result;
    }
    
    [HttpPut]
    public async Task<RideDTO> UpdateRide([FromBody] RideDTO ride)
    {
        var result = await _mediator.Send(new UpdateRide(ride));
        return result;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<Guid> DeleteRide(Guid id)
    {
        var result = await _mediator.Send(new DeleteRide(id));
        return result;
    }
}