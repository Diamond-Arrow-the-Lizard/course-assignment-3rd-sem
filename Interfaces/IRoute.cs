namespace AirlinesSystem.Interfaces;

public interface IRoute
{
    int RouteId { get; set; }
    string Departure { get; set; }
    DateTime DepartureTime { get; set; }
    string Arrival { get; set; }
    DateTime ArrivalTime { get; set; }
    string AircraftType { get; set; }
    IEnumerable<string> Stopovers { get; set; }
    List<DayOfWeek> DaysOfDeparture { get; set; }
}
