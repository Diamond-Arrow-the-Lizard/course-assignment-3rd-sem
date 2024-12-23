
namespace AirlinesSystem.Interfaces;

public interface IFlightCrewService
{
    Task<IEnumerable<IFlightCrew>> GetAllFlightCrewsAsync();
    Task<IFlightCrew> GetFlightCrewByIdAsync(string id);
    Task AddFlightCrewAsync(IFlightCrew FlightCrew);
    Task RemoveFlightCrewAsync(string id);
}
