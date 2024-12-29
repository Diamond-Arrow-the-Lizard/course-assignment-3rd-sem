
using System.Text.Json.Serialization;
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Route : IRoute
{
    public string RouteId { get; } = "Undefined";
    public string Departure { get; set; } = "Undefined";
    public DateTime DepartureTime { get; set; }
    public string Arrival { get; set; } = "Undefined";
    public DateTime ArrivalTime { get; set; }
    public string AircraftId { get; } = "Undefined";
    public IEnumerable<string> Stopovers { get; set; } = [];

    [JsonConstructor]
    public Route(string RouteId, string Departure, DateTime DepartureTime, 
    string Arrival, DateTime ArrivalTime, string AircraftId, 
    IEnumerable<string> Stopovers)
    {
        this.RouteId = RouteId;
        this.Departure = Departure;
        this.DepartureTime= DepartureTime;
        this.Arrival = Arrival;
        this.ArrivalTime = ArrivalTime;
        this.AircraftId = AircraftId;
        this.Stopovers = Stopovers;

    }
}
