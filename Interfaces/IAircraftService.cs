
namespace AirlinesSystem.Interfaces;

public interface IAircraftService
{
    Task<IEnumerable<IAircraft>> GetAllAircraftsAsync();
    Task<IAircraft> GetAircraftByIdAsync(int id);
    Task AddAircraftAsync(IAircraft aircraft);
    Task RemoveAircraftAsync(int id);
}
