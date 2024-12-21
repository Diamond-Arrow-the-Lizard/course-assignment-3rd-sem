
namespace AirlinesSystem.Interfaces;

public interface IFlightCrewService
{
    Task<IEnumerable<IFlightCrew>> GetAllFlightCrewsAsync();
    Task<IFlightCrew> GetFlightCrewByIdAsync(int id);
    Task AddFlightCrewAsync(IFlightCrew FlightCrew);
    Task RemoveFlightCrewAsync(int id);
}
