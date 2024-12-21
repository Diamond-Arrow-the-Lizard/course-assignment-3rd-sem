
namespace AirlinesSystem.Interfaces;

public interface ITicketService
{
    Task<List<ITicket>> GetAllTicketsAsync();       // Получить все билеты
    Task AddTicketAsync(ITicket ticket);             // Добавить новый билет
    Task SaveTicketsAsync(string filePath);        // Сохранить данные о билетах в файл
    Task LoadTicketsAsync(string filePath);        // Загрузить данные о билетах из файла
}
