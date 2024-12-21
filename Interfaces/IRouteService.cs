
namespace AirlinesSystem.Interfaces;

public interface IRouteService
{
    Task<List<IRoute>> GetAllRoutesAsync();  // Получить все маршруты
    Task AddRouteAsync(IRoute route);        // Добавить новый маршрут
    Task SaveRoutesAsync(string filePath);  // Сохранить данные о маршрутах в файл
    Task LoadRoutesAsync(string filePath);  // Загрузить данные о маршрутах из файла
}
