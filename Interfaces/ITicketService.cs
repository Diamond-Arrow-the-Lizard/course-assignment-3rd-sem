
namespace AirlinesSystem.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<ITicket>> GetAllTicketsAsync();
    Task<ITicket> GetTicketByIdAsync(int id);
    Task AddTicketAsync(ITicket ticket);
    Task RemoveTicketAsync(int id);
}
