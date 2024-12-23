namespace AirlinesSystem.Interfaces;

public interface IRoute
{
    string RouteId { get; } 
    string Departure { get; set; }
    DateTime DepartureTime { get; set; }
    string Arrival { get; set; }
    DateTime ArrivalTime { get; set; }
    string AircraftId { get; }
    IEnumerable<string> Stopovers { get; set; }
    List<DayOfWeek> DaysOfDeparture { get; set; }
}
