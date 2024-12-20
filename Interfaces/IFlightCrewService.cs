
namespace AirlinesSystem.Interfaces;

public interface IFlightCrewService
{
    void AddFlightCrew(IFlightCrew flightCrew);
    void UpdateFlightCrew(IFlightCrew flightCrew);
    void RemoveFlightCrew(string flightNumber, DateTime flightDate);
    IFlightCrew GetFlightCrew(string flightNumber, DateTime flightDate);
    List<IFlightCrew> GetAllFlightCrews();
}
