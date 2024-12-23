
namespace AirlinesSystem.Services;

public class RouteService : IRouteService
{
    private readonly IJsonHelper _jsonHelper;
    private readonly string _dataPath;

    public RouteService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper ?? throw new ArgumentNullException(nameof(jsonHelper));
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data", "routes.json");
        //Console.WriteLine($"Path to Route data file: {_dataPath}");
    }

    public async Task<IEnumerable<IRoute>> GetAllRoutesAsync()
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        return await _jsonHelper.DeserializeAsync<List<Route>>(json);
    }

    public async Task<IRoute> GetRouteByIdAsync(string id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Routes = await _jsonHelper.DeserializeAsync<List<Route>>(json);
        return Routes.FirstOrDefault(a => a.RouteId == id) ?? throw new Exception("Route wasn't found");
    }

    public async Task AddRouteAsync(IRoute Route)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Routes = await _jsonHelper.DeserializeAsync<List<Route>>(json);
        if (Route is Route a)
            Routes.Add(a);
        var updatedJson = await _jsonHelper.SerializeAsync(Routes);
        await File.WriteAllTextAsync(_dataPath, updatedJson);
    }

    public async Task RemoveRouteAsync(string id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Routes = await _jsonHelper.DeserializeAsync<List<Route>>(json);
        var Route = Routes.FirstOrDefault(a => a.RouteId == id);
        if (Route != null)
        {
            Routes.Remove(Route);
            var updatedJson = await _jsonHelper.SerializeAsync(Routes);
            await File.WriteAllTextAsync(_dataPath, updatedJson);
        }
    }
}
