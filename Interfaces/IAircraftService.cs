
namespace AirlinesSystem.Interfaces;

public interface IAircraftService
{
    void AddAircraft(IAircraft aircraft);
    void UpdateAircraft(IAircraft aircraft);
    void RemoveAircraft(string registrationNumber);
    IAircraft GetAircraft(string registrationNumber);
    List<IAircraft> GetAllAircraft();
}
