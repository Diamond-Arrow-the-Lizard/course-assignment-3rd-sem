
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Route : IRoute
{
    public int RouteId { get; set; }
    public string Departure { get; set; } = "Undefined";
    public DateTime DepartureTime { get; set; }
    public string Arrival { get; set; } = "Undefined";
    public DateTime ArrivalTime { get; set; }
    public string AircraftType { get; set; } = "Undefined";
    public IEnumerable<string> Stopovers { get; set; } = new List<string>();
    public List<DayOfWeek> DaysOfDeparture { get; set; } = [];
}
