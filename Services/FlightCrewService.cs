
namespace AirlinesSystem.Services;

public class FlightCrewService : IFlightCrewService
{
    private readonly IJsonHelper _jsonHelper;
    private readonly string _dataPath;

    public FlightCrewService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper ?? throw new ArgumentNullException(nameof(jsonHelper));
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data", "flightCrews.json");
        //Console.WriteLine($"Path to FlightCrew data file: {_dataPath}");
    }

    public async Task<IEnumerable<IFlightCrew>> GetAllFlightCrewsAsync()
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        return await _jsonHelper.DeserializeAsync<List<FlightCrew>>(json);
    }

    public async Task<IFlightCrew> GetFlightCrewByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<FlightCrew>>(json);
        return FlightCrews.FirstOrDefault(a => a.FlightId == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddFlightCrewAsync(IFlightCrew FlightCrew)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<FlightCrew>>(json);
        if (FlightCrew is FlightCrew a)
            FlightCrews.Add(a);
        var updatedJson = await _jsonHelper.SerializeAsync(FlightCrews);
        await File.WriteAllTextAsync(_dataPath, updatedJson);
    }

    public async Task RemoveFlightCrewAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var FlightCrews = await _jsonHelper.DeserializeAsync<List<FlightCrew>>(json);
        var FlightCrew = FlightCrews.FirstOrDefault(a => a.FlightId == id);
        if (FlightCrew != null)
        {
            FlightCrews.Remove(FlightCrew);
            var updatedJson = await _jsonHelper.SerializeAsync(FlightCrews);
            await File.WriteAllTextAsync(_dataPath, updatedJson);
        }
    }
}
