
namespace AirlinesSystem.Interfaces;

public interface IAircraftService
{
    Task<IEnumerable<IAircraft>> GetAllAircraftsAsync();
    Task<IAircraft> GetAircraftByIdAsync(string id);
    Task AddAircraftAsync(IAircraft aircraft);
    Task RemoveAircraftAsync(string id);
}
