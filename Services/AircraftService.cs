
namespace AirlinesSystem.Services;

public class AircraftService : IAircraftService
{
    private readonly IJsonHelper _jsonHelper;
    private readonly string _dataPath;

    public AircraftService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper ?? throw new ArgumentNullException(nameof(jsonHelper));
        _dataPath = Path.Combine("..", "Data", "Data", "aircraft.json");
    }

    public async Task<IEnumerable<IAircraft>> GetAllAircraftsAsync()
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        return await _jsonHelper.DeserializeAsync<List<IAircraft>>(json);
    }

    public async Task<IAircraft> GetAircraftByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var aircrafts = await _jsonHelper.DeserializeAsync<List<IAircraft>>(json);
        return aircrafts.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddAircraftAsync(IAircraft aircraft)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var aircrafts = await _jsonHelper.DeserializeAsync<List<IAircraft>>(json);
        aircrafts.Add(aircraft);
        var updatedJson = await _jsonHelper.SerializeAsync(aircrafts);
        await File.WriteAllTextAsync("aircrafts.json", updatedJson);
    }

    public async Task RemoveAircraftAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var aircrafts = await _jsonHelper.DeserializeAsync<List<IAircraft>>(json);
        var aircraft = aircrafts.FirstOrDefault(a => a.Id == id);
        if (aircraft != null)
        {
            aircrafts.Remove(aircraft);
            var updatedJson = await _jsonHelper.SerializeAsync(aircrafts);
            await File.WriteAllTextAsync(_dataPath, updatedJson);
        }
    }
}
