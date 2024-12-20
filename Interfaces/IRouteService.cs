
namespace AirlinesSystem.Interfaces;

public interface IRouteService
{
    void AddRoute(IRoute route);
    void UpdateRoute(IRoute route);
    void RemoveRoute(string routeCode);
    IRoute GetRoute(string routeCode);
    List<IRoute> GetAllRoutes();
}
