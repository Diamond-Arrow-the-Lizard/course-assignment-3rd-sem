
namespace AirlinesSystem.Services;

public class FlightCrewService : IFlightCrewService
{
    private readonly IJsonHelper _jsonHelper;

    public FlightCrewService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper;
    }

    public async Task<IEnumerable<IFlightCrew>> GetAllFlightCrewsAsync()
    {
        var json = await File.ReadAllTextAsync("FlightCrews.json");
        return await _jsonHelper.DeserializeAsync<List<IFlightCrew>>(json);
    }

    public async Task<IFlightCrew> GetFlightCrewByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync("FlightCrews.json");
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<IFlightCrew>>(json);
        return FlightCrews.FirstOrDefault(a => a.FlightId == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddFlightCrewAsync(IFlightCrew FlightCrew)
    {
        var json = await File.ReadAllTextAsync("FlightCrews.json");
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<IFlightCrew>>(json);
        FlightCrews.Add(FlightCrew);
        var updatedJson = await _jsonHelper.SerializeAsync(FlightCrews);
        await File.WriteAllTextAsync("FlightCrews.json", updatedJson);
    }

    public async Task RemoveFlightCrewAsync(int id)
    {
        var json = await File.ReadAllTextAsync("FlightCrews.json");
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<IFlightCrew>>(json);
        var FlightCrew = FlightCrews.FirstOrDefault(a => a.FlightId == id);
        if (FlightCrew != null)
        {
            FlightCrews.Remove(FlightCrew);
            var updatedJson = await _jsonHelper.SerializeAsync(FlightCrews);
            await File.WriteAllTextAsync("FlightCrews.json", updatedJson);
        }
    }
}
