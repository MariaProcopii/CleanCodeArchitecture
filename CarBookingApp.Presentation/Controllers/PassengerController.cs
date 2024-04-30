using CarBookingApp.Application.Passangers.Commands;
using CarBookingApp.Application.Passangers.Queries;
using CarBookingApp.Application.Passangers.Responses;
using CarBoookingApp.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingApp.PresentationWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class PassengerController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;

    private readonly IMediator _mediator;

    public PassengerController(ILogger<PassengerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<PassengerDTO> GetPassengerById(Guid id)
    {
        var result = await _mediator.Send(new GetPassengerById(id));
        return result;
    }
    
    [HttpGet]
    public async Task<List<PassengerDTO>> GetPassengers()
    {
        var retrievedPassenger = await _mediator.Send(new GetAllPassengers());
        return retrievedPassenger;
    }
    
    [HttpPost]
    public async Task<PassengerDTO> CreatePassenger([FromBody] PassengerDTO passenger)
    {
        var result = await _mediator.Send(new CreatePassenger(Name: passenger.Name, Email: passenger.Email));
        return result;
    }
    
    [HttpPut]
    public async Task<PassengerDTO> UpdatePassenger([FromBody] PassengerDTO passenger)
    {
        var result = await _mediator.Send(new UpdatePassenger(passenger));
        return result;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<Guid> DeletePassenger(Guid id)
    {
        var result = await _mediator.Send(new DeletePassenger(id));
        return result;
    }
}