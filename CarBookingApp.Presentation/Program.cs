using CarBookingApp.Application.Abstractions;
using CarBookingApp.Application.Drivers.Commands;
using CarBookingApp.Application.Drivers.Queries;
using CarBookingApp.Application.Passangers.Commands;
using CarBookingApp.Application.Passangers.Queries;
using CarBookingApp.Application.Rides.Commands;
using CarBookingApp.Application.Rides.Queries;
using CarBookingApp.Infrastructure;
using CarBookingApp.Infrastructure.Configurations;
using CarBookingApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var diContainer = new ServiceCollection()
    .AddDbContext<CarBookingAppDbContext>(options =>
        options.UseNpgsql("Host=localhost;Port=5432;Database=carbooking;Username=maria;Password=maria;"))
    .AddSingleton<IDriverRepository, DriverRepository>()
    .AddSingleton<IPassengerRepository, PassengerRepository>()
    .AddSingleton<IRideRepository, RideRepository>()
    .AddSingleton<IUnitOfWork, UnitOfWork>()
    .AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(typeof(IRideRepository).Assembly))
    .BuildServiceProvider();
    
var mediator = diContainer.GetRequiredService<IMediator>();
//========Passenger
 var passenger1 = await mediator.Send(new CreatePassenger(Name:"Passenger1", 
     Email:"mari.procopii@gmail.com", PaymentMethod: "cash"));
 passenger1.Name = "NewPassenger1";
 await mediator.Send(new UpdatePassenger(passenger1));

 var passengers = await mediator.Send(new GetAllPassengers());
 foreach (var p in passengers)
 {
     Console.WriteLine(p);
 }
 var retrievedPassenger = await mediator.Send(new GetPassengerById(passenger1.Id));
 Console.WriteLine(retrievedPassenger);
await mediator.Send(new DeletePassenger(passenger1.Id));

//=========Driver
 var driver = await mediator.Send(new CreateDriver(Name: "Driver1", 
     Email: "example@gmai.com", LicenseNumber: " ABC 123"));
 driver.Name = "newDriver";
 await mediator.Send(new UpdateDriver(driver));
 var updatedDriver = await mediator.Send(new UpdateDriver(driver));
 var drivers = await mediator.Send(new GetAllDrivers());
 foreach (var d in drivers)
 {
     Console.WriteLine(d);
 }
await mediator.Send(new DeleteDriver(Guid.Parse("ade0ed75-8889-452b-969f-9b050a5dcc5c")));

//==========Ride
 var ride = await mediator.Send(new CreateRide(OwnerId: Guid.Parse("3778ce71-c01c-45dc-9f98-cc1524b9dec8"),
     DestinationFrom: "Chisinau", DestinationTo: "Comrat",
     DateOfTheRide: DateTime.Now.ToUniversalTime(), AvailableSeats: 3));

 await mediator.Send(new BookRide(RideId: Guid.Parse("7c5ceabf-a7d3-420b-8b2c-90ea1e647589"),
     PassengerId: Guid.Parse("dd7c727a-344b-4014-8edc-d4ff77478221")));

 await mediator.Send(new RemovePassengerFromRide(RideId: Guid.Parse("7c5ceabf-a7d3-420b-8b2c-90ea1e647589"),
     PassengerId: Guid.Parse("dd7c727a-344b-4014-8edc-d4ff77478221")));

var rides = await mediator.Send(new GetAllRides());
foreach (var r in rides)
{
    Console.WriteLine(r);
}

await mediator.Send(new DeleteRide(Guid.Parse("89475ae2-58ef-42f3-a407-ab7f68c3b200")));
