
namespace AirlinesSystem.Console;

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AirlinesSystem.Modules;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
class Program
{
    static async Task Main(string[] args)
    {
        // Настройка Dependency Injection
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        // Получение сервисов
        var aircraftService = serviceProvider.GetService<IAircraftService>();
        var routeService = serviceProvider.GetService<IRouteService>();
        var ticketService = serviceProvider.GetService<ITicketService>();
        var searchService = serviceProvider.GetService<ISearchService>();

        // Главное меню
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Airline Management System ===");
            Console.WriteLine("1. Load and display all aircrafts");
            Console.WriteLine("2. Load and display all routes");
            Console.WriteLine("3. Load and display all tickets");
            Console.WriteLine("4. Search data");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await DisplayAircraftsAsync(aircraftService);
                    break;
                case "2":
                    await DisplayRoutesAsync(routeService);
                    break;
                case "3":
                    await DisplayTicketsAsync(ticketService);
                    break;
                case "4":
                    await SearchDataAsync(searchService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    // Конфигурация DI
    static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        // Регистрация хелперов
        services.AddSingleton<IJsonHelper, JsonHelper>();

        // Регистрация сервисов
        services.AddSingleton<IAircraftService, AircraftService>();
        services.AddSingleton<IRouteService, RouteService>();
        services.AddSingleton<ITicketService, TicketService>();
        services.AddSingleton<ISearchService, SearchService>();

        return services;
    }

    // Методы для отображения данных

    static async Task DisplayAircraftsAsync(IAircraftService aircraftService)
    {
        var aircrafts = await aircraftService.GetAllAircraftsAsync();
        Console.WriteLine("=== Aircrafts ===");
        foreach (var aircraft in aircrafts)
        {
            Console.WriteLine($"Type: {aircraft.Type}, Board Number: {aircraft.BoardNumber}, Year: {aircraft.Year}, Last Check: {aircraft.LastMaintenanceDate}");
        }
    }

    static async Task DisplayRoutesAsync(IRouteService routeService)
    {
        var routes = await routeService.GetAllRoutesAsync();
        Console.WriteLine("=== Routes ===");
        foreach (var route in routes)
        {
            Console.WriteLine($"Code: {route.Code}, Start: {route.StartLocation}, End: {route.EndLocation}, Days: {string.Join(", ", route.DaysOfFlight)}");
        }
    }

    static async Task DisplayTicketsAsync(ITicketService ticketService)
    {
        var tickets = await ticketService.GetAllTicketsAsync();
        Console.WriteLine("=== Tickets ===");
        foreach (var ticket in tickets)
        {
            Console.WriteLine($"Passenger: {ticket.PassengerName}, Flight: {ticket.FlightNumber}, Seat: {ticket.SeatNumber}, Price: {ticket.Price}");
        }
    }

    static async Task SearchDataAsync(ISearchService searchService)
    {
        Console.WriteLine("Enter search term: ");
        var searchTerm = Console.ReadLine();

        Console.WriteLine("\n=== Search Results ===");

        var aircrafts = await searchService.SearchAircraftsAsync(searchTerm);
        Console.WriteLine("\nAircrafts:");
        foreach (var aircraft in aircrafts)
        {
            Console.WriteLine($"Type: {aircraft.Type}, Board Number: {aircraft.BoardNumber}");
        }

        var routes = await searchService.SearchRoutesAsync(searchTerm);
        Console.WriteLine("\nRoutes:");
        foreach (var route in routes)
        {
            Console.WriteLine($"Code: {route.Code}, Start: {route.StartLocation}, End: {route.EndLocation}");
        }

        var tickets = await searchService.SearchTicketsAsync(searchTerm);
        Console.WriteLine("\nTickets:");
        foreach (var ticket in tickets)
        {
            Console.WriteLine($"Passenger: {ticket.PassengerName}, Flight: {ticket.FlightNumber}");
        }
    }
}
