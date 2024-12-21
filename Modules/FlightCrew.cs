
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class FlightCrew : IFlightCrew
{
    public int FlightId { get; set; }
    public IEnumerable<ICrewMember> CrewMembers { get; set; } = Enumerable.Empty<ICrewMember>();
}
