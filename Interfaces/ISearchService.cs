
namespace AirlinesSystem.Interfaces;

public interface ISearchService
{
    List<IRoute> SearchRoutes(string startPoint, string endPoint, DateTime date);
    List<ITicket> SearchTickets(string passengerName, DateTime? date = null);
}
