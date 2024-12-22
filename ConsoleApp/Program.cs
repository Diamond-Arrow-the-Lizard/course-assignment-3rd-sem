
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
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        // Получение сервисов
        var aircraftService = serviceProvider.GetService<AircraftService>();
        var routeService = serviceProvider.GetService<RouteService>();
        var ticketService = serviceProvider.GetService<TicketService>();
        var searchService = serviceProvider.GetService<SearchService>();

        var aircrafts = await aircraftService.GetAllAircraftsAsync();

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
/* 

    static async Task DisplayAircraftsAsync(IAircraftService aircraftService)
    {
        var aircrafts = await aircraftService.GetAllAircraftsAsync();
        Console.WriteLine("=== Aircrafts ===");
        foreach (var aircraft in aircrafts)
        {
            Console.WriteLine($"Type: {aircraft.Type}, Board Number: {aircraft.RegistrationNumber}, Year: {aircraft.YearOfManufacture}, Last Check: {aircraft.LastMaintenance}");
        }
    }

    static async Task DisplayRoutesAsync(IRouteService routeService)
    {
        var routes = await routeService.GetAllRoutesAsync();
        Console.WriteLine("=== Routes ===");
        foreach (var route in routes)
        {
            Console.WriteLine($"Id: {route.RouteId}, Start: {route.Departure}, End: {route.Arrival}, Days: {string.Join($"{route.DepartureTime} - ", route.ArrivalTime)}");
        }
    }

    static async Task DisplayTicketsAsync(ITicketService ticketService)
    {
        var tickets = await ticketService.GetAllTicketsAsync();
        Console.WriteLine("=== Tickets ===");
        foreach (var ticket in tickets)
        {
            Console.WriteLine($"Passenger: {ticket.PassengerName}, Flight: {ticket.FlightId}, Seat: {ticket.SeatNumber}, Price: {ticket.Price}");
        }
    }

    static async Task SearchDataAsync(ISearchService searchService)
    {
        Console.WriteLine("Enter search term: ");
        var searchTerm = Console.ReadLine();

        Console.WriteLine("\n=== Search Results ===");

        if (searchTerm != null)
        {
            var aircrafts = await searchService.SearchAircraftsAsync(searchTerm);

            Console.WriteLine("\nAircrafts:");
            foreach (var aircraft in aircrafts)
            {
                Console.WriteLine($"Type: {aircraft.Type}, Board Number: {aircraft.RegistrationNumber}");
            }

            var routes = await searchService.SearchRoutesAsync(searchTerm);
            Console.WriteLine("\nRoutes:");
            foreach (var route in routes)
            {
                Console.WriteLine($"Code: {route.RouteId}, Start: {route.Departure}, End: {route.Arrival}");
            }
            
                        var tickets = await searchService.SearchTicketsAsync(searchTerm);
                        Console.WriteLine("\nTickets:");
                        foreach (var ticket in tickets)
                        {
                            Console.WriteLine($"Passenger: {ticket.PassengerName}, Flight: {ticket.FlightId}");
                        }
                        
        }
        
    }
*/
}
