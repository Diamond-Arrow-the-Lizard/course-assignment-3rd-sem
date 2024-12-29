
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

        var routeService = serviceProvider.GetService<IRouteService>();
        var ticketService = serviceProvider.GetService<ITicketService>();
        var searchService = serviceProvider.GetService<ISearchService>();

        var newRoute = new Route
        (
            "A1080",
            "Moscow",
            DateTime.Today,
            "Magadan",
            new DateTime(2024, 12, 31),
            "12347",
            [],
            [DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday]
        );

        if (routeService != null)
        {
            await routeService.AddRouteAsync(newRoute);
            var routeCopy = await routeService.GetRouteByIdAsync("A1080");
            Console.WriteLine(routeCopy.RouteId);
        }
        if (aircraftService != null) {
            Console.WriteLine((await aircraftService.GetAircraftByIdAsync("12347")).Type);
        }

    }

}
