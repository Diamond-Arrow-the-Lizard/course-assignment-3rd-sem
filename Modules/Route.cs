
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Route : IRoute
{
    private string routeCode = "";
    private string startPoint = "";
    private DateTime departureTime;
    private string endPoint = "";
    private DateTime arrivalTime;
    private List<string> daysOfDeparture = new();
    private string aircraftType = ""; 
    private List<string>? intermediateStops;

    public string RouteCode
    {
        get => routeCode;
        set => routeCode = value;
    }

    public string StartPoint
    {
        get => startPoint;
        set => startPoint = value;
    }

    public DateTime DepartureTime
    {
        get => departureTime;
        set => departureTime = value;
    }

    public string EndPoint
    {
        get => endPoint;
        set => endPoint = value;
    }

    public DateTime ArrivalTime
    {
        get => arrivalTime;
        set => arrivalTime = value;
    }

    public List<string> DaysOfDeparture
    {
        get => daysOfDeparture;
        set => daysOfDeparture = value;
    }

    public string AircraftType
    {
        get => aircraftType;
        set => aircraftType = value;
    }

    public List<string>? IntermediateStops
    {
        get => intermediateStops;
        set => intermediateStops = value;
    }
}
