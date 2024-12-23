
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class FlightCrew : IFlightCrew
{
    public string FlightCrewId { get; } = "Undefined";
    public IEnumerable<ICrewMember> CrewMembers { get; set; } = Enumerable.Empty<ICrewMember>();
}
