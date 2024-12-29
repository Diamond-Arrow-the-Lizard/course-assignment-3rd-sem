
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
        await Task.Delay(0);

        // Настройка Dependency Injection
        var services = new ServiceCollection();

        // Регистрация хелперов
        services.AddSingleton<IJsonHelper, JsonHelper>();

        // Регистрация сервисов
        services.AddSingleton<IAircraftService, AircraftService>();
        services.AddSingleton<IRouteService, RouteService>();
        services.AddSingleton<ITicketService, TicketService>();

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


    }

}
