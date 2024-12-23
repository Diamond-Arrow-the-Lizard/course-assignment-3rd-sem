
namespace AirlinesSystem.Services;

public class TicketService : ITicketService
{
    private readonly IJsonHelper _jsonHelper;
    private readonly string _dataPath;

    public TicketService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper ?? throw new ArgumentNullException(nameof(jsonHelper));
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data", "tickets.json");
        //Console.WriteLine($"Path to Ticket data file: {_dataPath}");
    }

    public async Task<IEnumerable<ITicket>> GetAllTicketsAsync()
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        return await _jsonHelper.DeserializeAsync<List<Ticket>>(json);
    }

    public async Task<ITicket> GetTicketByIdAsync(string id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Tickets = await _jsonHelper.DeserializeAsync<List<Ticket>>(json);
        return Tickets.FirstOrDefault(a => a.TicketId == id) ?? throw new Exception("Ticket wasn't found");
    }

    public async Task AddTicketAsync(ITicket Ticket)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Tickets = await _jsonHelper.DeserializeAsync<List<Ticket>>(json);
        if (Ticket is Ticket a)
            Tickets.Add(a);
        var updatedJson = await _jsonHelper.SerializeAsync(Tickets);
        await File.WriteAllTextAsync(_dataPath, updatedJson);
    }

    public async Task RemoveTicketAsync(string id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var Tickets = await _jsonHelper.DeserializeAsync<List<Ticket>>(json);
        var Ticket = Tickets.FirstOrDefault(a => a.TicketId == id);
        if (Ticket != null)
        {
            Tickets.Remove(Ticket);
            var updatedJson = await _jsonHelper.SerializeAsync(Tickets);
            await File.WriteAllTextAsync(_dataPath, updatedJson);
        }
    }
}
