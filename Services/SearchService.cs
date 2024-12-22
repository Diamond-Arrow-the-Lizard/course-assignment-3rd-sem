
namespace AirlinesSystem.Services;

public class SearchService : ISearchService
{
    private readonly IAircraftService _aircraftService;
    private readonly IRouteService _routeService;
    private readonly ITicketService _ticketService;

    public SearchService(IAircraftService aircraftService, IRouteService routeService, ITicketService ticketService)
    {
        _aircraftService = aircraftService;
        _routeService = routeService;
        _ticketService = ticketService;
    }

    public async Task<IEnumerable<IAircraft>> SearchAircraftsAsync(string searchTerm)
    {
        // Загружаем все авиалайнеры
        var aircrafts = await _aircraftService.GetAllAircraftsAsync();

        // Фильтруем авиалайнеры по поисковому запросу
        return aircrafts.Where(a => a.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                      a.RegistrationNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<IRoute>> SearchRoutesAsync(string searchTerm)
    {
        // Загружаем все маршруты
        var routes = await _routeService.GetAllRoutesAsync();

        // Фильтруем маршруты по поисковому запросу
        return routes.Where(r => r.Departure.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                  r.Arrival.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }

        //TODO
        public async Task<IEnumerable<ITicket>> SearchTicketsAsync(string searchTerm)
        {
            return await _ticketService.GetAllTicketsAsync();
            /*
            // Загружаем все билеты
            var tickets = await _ticketService.GetAllTicketsAsync();

            // Фильтруем билеты по поисковому запросу
            return tickets.Where(t => t.PassengerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                      t.FlightId);
        */
        }
}
