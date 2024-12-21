
namespace AirlinesSystem.Services;

public class TicketService : ITicketService
{
    private readonly IJsonHelper _jsonHelper;

    public TicketService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper;
    }

    public async Task<IEnumerable<ITicket>> GetAllTicketsAsync()
    {
        var json = await File.ReadAllTextAsync("Tickets.json");
        return await _jsonHelper.DeserializeAsync<List<ITicket>>(json);
    }

    public async Task<ITicket> GetTicketByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync("Tickets.json");
        var Tickets = await _jsonHelper.DeserializeAsync<List<ITicket>>(json);
        return Tickets.FirstOrDefault(a => a.TicketId == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddTicketAsync(ITicket Ticket)
    {
        var json = await File.ReadAllTextAsync("Tickets.json");
        var Tickets = await _jsonHelper.DeserializeAsync<List<ITicket>>(json);
        Tickets.Add(Ticket);
        var updatedJson = await _jsonHelper.SerializeAsync(Tickets);
        await File.WriteAllTextAsync("Tickets.json", updatedJson);
    }

    public async Task RemoveTicketAsync(int id)
    {
        var json = await File.ReadAllTextAsync("Tickets.json");
        var Tickets = await _jsonHelper.DeserializeAsync<List<ITicket>>(json);
        var Ticket = Tickets.FirstOrDefault(a => a.TicketId == id);
        if (Ticket != null)
        {
            Tickets.Remove(Ticket);
            var updatedJson = await _jsonHelper.SerializeAsync(Tickets);
            await File.WriteAllTextAsync("Tickets.json", updatedJson);
        }
    }
}
