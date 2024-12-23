
namespace AirlinesSystem.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<ITicket>> GetAllTicketsAsync();
    Task<ITicket> GetTicketByIdAsync(string id);
    Task AddTicketAsync(ITicket ticket);
    Task RemoveTicketAsync(string id);
}
