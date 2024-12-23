
namespace AirlinesSystem.Console;

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
using AirlinesSystem.Modules;

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
            Console.WriteLine(aircraft.Type + aircraft.AircraftId);

        try
        {
            var myAircraft = await aircraftService.GetAircraftByIdAsync("12345");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        var newAircraft = new Aircraft
        (
            "12350",
            "Boeing 747",
            "779",
            DateTime.Now,
            DateTime.UtcNow,
            "Undefined"
        );


        await aircraftService.AddAircraftAsync(newAircraft);
        await aircraftService.RemoveAircraftAsync("12348");

    }

}
