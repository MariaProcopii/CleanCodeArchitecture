using CarBookingApp.Application.Drivers.Commands;
using CarBookingApp.Application.Drivers.Queries;
using CarBookingApp.Application.Drivers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingApp.PresentationWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;

    private readonly IMediator _mediator;

    public DriverController(ILogger<PassengerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<DriverDTO> GetDriverById(Guid id)
    {
        var result = await _mediator.Send(new GetDriverById(id));
        return result;
    }
    
    [HttpGet]
    public async Task<List<DriverDTO>> GetDrivers()
    {
        var result = await _mediator.Send(new GetAllDrivers());
        return result;
    }
    
    [HttpPost]
    public async Task<DriverDTO> CreateUser([FromBody] DriverDTO driver)
    {
        var result = await _mediator.Send(new CreateDriver(Name: driver.Name, Email: driver.Email, 
            LicenseNumber: driver.LicenseNumber));
        return result;
    }
    
    [HttpPut]
    public async Task<DriverDTO> UpdateDriver([FromBody] DriverDTO driver)
    {
        var result = await _mediator.Send(new UpdateDriver(driver));
        return result;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<Guid> DeleteDriver(Guid id)
    {
        var result = await _mediator.Send(new DeleteDriver(id));
        return result;
    }
}