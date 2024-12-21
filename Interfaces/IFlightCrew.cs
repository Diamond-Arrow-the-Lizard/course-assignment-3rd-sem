namespace AirlinesSystem.Interfaces;

public interface IFlightCrew
{
    int FlightId { get; set; }
    IEnumerable<ICrewMember> CrewMembers { get; set; }
}
