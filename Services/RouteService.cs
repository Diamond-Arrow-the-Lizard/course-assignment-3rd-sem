
namespace AirlinesSystem.Services;

public class RouteService : IRouteService
{
    private readonly IJsonHelper _jsonHelper;

    public RouteService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper;
    }

    public async Task<IEnumerable<IRoute>> GetAllRoutesAsync()
    {
        var json = await File.ReadAllTextAsync("Routes.json");
        return await _jsonHelper.DeserializeAsync<List<IRoute>>(json);
    }

    public async Task<IRoute> GetRouteByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync("Routes.json");
        var Routes = await _jsonHelper.DeserializeAsync<List<IRoute>>(json);
        return Routes.FirstOrDefault(a => a.RouteId == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddRouteAsync(IRoute Route)
    {
        var json = await File.ReadAllTextAsync("Routes.json");
        var Routes = await _jsonHelper.DeserializeAsync<List<IRoute>>(json);
        Routes.Add(Route);
        var updatedJson = await _jsonHelper.SerializeAsync(Routes);
        await File.WriteAllTextAsync("Routes.json", updatedJson);
    }

    public async Task RemoveRouteAsync(int id)
    {
        var json = await File.ReadAllTextAsync("Routes.json");
        var Routes = await _jsonHelper.DeserializeAsync<List<IRoute>>(json);
        var Route = Routes.FirstOrDefault(a => a.RouteId == id);
        if (Route != null)
        {
            Routes.Remove(Route);
            var updatedJson = await _jsonHelper.SerializeAsync(Routes);
            await File.WriteAllTextAsync("Routes.json", updatedJson);
        }
    }
}
