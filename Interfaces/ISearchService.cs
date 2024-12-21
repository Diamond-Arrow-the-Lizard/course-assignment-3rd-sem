
namespace AirlinesSystem.Interfaces;

public interface ISearchService
{
    Task<IEnumerable<IAircraft>> SearchAircraftsAsync(string query);
    Task<IEnumerable<IRoute>> SearchRoutesAsync(string query);
    Task<IEnumerable<ITicket>> SearchTicketsAsync(string query);
}
