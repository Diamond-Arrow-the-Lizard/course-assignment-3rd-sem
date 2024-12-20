namespace AirlinesSystem.Interfaces;

public interface IRoute
{
    string RouteCode { get; set; }
    string StartPoint { get; set; }
    DateTime DepartureTime { get; set; }
    string EndPoint { get; set; }
    DateTime ArrivalTime { get; set; }
    List<string> DaysOfDeparture { get; set; }
    string AircraftType { get; set; }
    List<string>? IntermediateStops { get; set; }
}
