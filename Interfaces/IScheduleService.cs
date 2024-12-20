
namespace AirlinesSystem.Interfaces;

public interface IScheduleService
{
    List<IRoute> GetRoutesByDay(string dayOfWeek);
    List<IFlightCrew> GetFlightCrewsForDate(DateTime date);
    List<ITicket> GetTicketsForFlight(string flightNumber, DateTime flightDate);
}
