
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

class FlightCrew : IFlightCrew
{
    private string flightNumber = "";
    private DateTime flightDate;
    private List<ICrewMember> crewMembers = new();

    public string FlightNumber
    {
        get => flightNumber;
        set => flightNumber = value;
    }

    public DateTime FlightDate
    {
        get => flightDate;
        set => flightDate = value;
    }

    public List<ICrewMember> CrewMembers
    {
        get => crewMembers;
        set => crewMembers = value;
    }
}
