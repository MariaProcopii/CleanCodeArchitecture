using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Commands;
using CarBookingApp.Application.Passangers.Commands;
using CarBookingApp.Application.Passangers.Queries;
using CarBookingApp.Application.Rides.Commands;
using CarBookingApp.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var diContainer = new ServiceCollection()
    .AddSingleton<IDriverRepository, DriverRepository>()
    .AddSingleton<IPassengerRepository, PassengerRepository>()
    .AddSingleton<IRideRepository, RideRepository>()
    .AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(typeof(IRideRepository).Assembly))
    .BuildServiceProvider();
    
var mediator = diContainer.GetRequiredService<IMediator>();

var passenger1 = await mediator.Send(new CreatePassenger(Name:"Passenger1", Email:"mari.procopii@gmail.com", PaymentMethod:"Card"));
var passenger2 = await mediator.Send(new CreatePassenger(Name:"Passenger2", Email:"alex.procopii@gmail.com", PaymentMethod:"Card"));
var driver = await mediator.Send(new CreateDriver(Name: "Driver1", Email: "example@gmai.com", CarModel: "Toyota", LicenseNumber: ""));
var ride = await mediator.Send(new CreateRide(OwnerId: driver.Id, DestinationFrom: "Chisinau", DestinationTo: "Comrat",
    DateOfTheRide: DateTime.Now, AvailableSeats: 3));

await mediator.Send(new BookRide(RideId: ride.Id, PassengerId: passenger1.Id));
await mediator.Send(new BookRide(RideId: ride.Id, PassengerId: passenger2.Id));

passenger1 = await mediator.Send(new GetPassengerById(passenger1.Id));

Console.WriteLine(passenger1);