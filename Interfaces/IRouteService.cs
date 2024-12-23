
namespace AirlinesSystem.Interfaces;

public interface IRouteService
{
    Task<IEnumerable<IRoute>> GetAllRoutesAsync();
    Task<IRoute> GetRouteByIdAsync(string id);
    Task AddRouteAsync(IRoute route);
    Task RemoveRouteAsync(string id);
}
