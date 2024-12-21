
namespace AirlinesSystem.Interfaces;

public interface IAircraftService
{
    Task<List<IAircraft>> GetAllAircraftsAsync();  // Получить все авиалайнеры
    Task AddAircraftAsync(IAircraft aircraft);     // Добавить новый авиалайнер
    Task SaveAircraftsAsync(string filePath);     // Сохранить данные о авиалайнерах в файл
    Task LoadAircraftsAsync(string filePath);     // Загрузить данные о авиалайнерах из файла
}
