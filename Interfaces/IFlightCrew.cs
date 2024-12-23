namespace AirlinesSystem.Interfaces;

public interface IFlightCrew
{
    string FlightCrewId { get; } 
    IEnumerable<ICrewMember> CrewMembers { get; set; }
}
