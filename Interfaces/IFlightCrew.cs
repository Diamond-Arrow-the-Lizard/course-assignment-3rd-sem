namespace AirlinesSystem.Interfaces;

public interface IFlightCrew
{
    string FlightNumber { get; set; }
    DateTime FlightDate { get; set; }
    List<ICrewMember> CrewMembers { get; set; }
}
