
namespace AirlinesSystem.Console;

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;

public class Program
{
    static async Task Main(string[] args)
    {
        // Настройка Dependency Injection
        var services = new ServiceCollection();

        // Регистрация хелперов
        services.AddSingleton<IJsonHelper, JsonHelper>();

        // Регистрация сервисов
        services.AddSingleton<IAircraftService, AircraftService>();
        services.AddSingleton<IRouteService, RouteService>();
        services.AddSingleton<ITicketService, TicketService>();
        services.AddSingleton<ISearchService, SearchService>();

        var serviceProvider = services.BuildServiceProvider();

        // Получение сервисов
        var aircraftService = serviceProvider.GetService<IAircraftService>();
        if (aircraftService == null)
        {
            Console.WriteLine("Error: AircraftService is not registered.");
            return;
        }

        var routeService = serviceProvider.GetService<RouteService>();
        var ticketService = serviceProvider.GetService<TicketService>();
        var searchService = serviceProvider.GetService<SearchService>();

        var aircrafts = await aircraftService.GetAllAircraftsAsync();
        foreach (var aircraft in aircrafts)
            Console.WriteLine(aircraft.Type + aircraft.Id);

        var myAircraft = await aircraftService.GetAircraftByIdAsync(12345);
        myAircraft.Id = 12348;
        Console.WriteLine(myAircraft.YearOfManufacture);

        await aircraftService.AddAircraftAsync(myAircraft);
        await aircraftService.RemoveAircraftAsync(12345);
    }

}
