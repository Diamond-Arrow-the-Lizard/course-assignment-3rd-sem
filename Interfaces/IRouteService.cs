
namespace AirlinesSystem.Interfaces;

public interface IRouteService
{
    Task<IEnumerable<IRoute>> GetAllRoutesAsync();
    Task<IRoute> GetRouteByIdAsync(int id);
    Task AddRouteAsync(IRoute route);
    Task RemoveRouteAsync(int id);
}
