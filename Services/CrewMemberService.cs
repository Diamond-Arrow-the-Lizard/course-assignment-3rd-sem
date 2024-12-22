
namespace AirlinesSystem.Services;

public class CrewMemberService : ICrewMemberService
{
    private readonly IJsonHelper _jsonHelper;
    private readonly string _dataPath;

    public CrewMemberService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper ?? throw new ArgumentNullException(nameof(jsonHelper));
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data", "crewMembers.json");
        //Console.WriteLine($"Path to CrewMember data file: {_dataPath}");
    }

    public async Task<IEnumerable<ICrewMember>> GetAllCrewMembersAsync()
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        return await _jsonHelper.DeserializeAsync<List<CrewMember>>(json);
    }

    public async Task<ICrewMember> GetCrewMemberByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var CrewMembers = await _jsonHelper.DeserializeAsync<List<CrewMember>>(json);
        return CrewMembers.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Crew member wasn't found");
    }

    public async Task AddCrewMemberAsync(ICrewMember CrewMember)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var CrewMembers = await _jsonHelper.DeserializeAsync<List<CrewMember>>(json);
        if (CrewMember is CrewMember a)
            CrewMembers.Add(a);
        var updatedJson = await _jsonHelper.SerializeAsync(CrewMembers);
        await File.WriteAllTextAsync(_dataPath, updatedJson);
    }

    public async Task RemoveCrewMemberAsync(int id)
    {
        var json = await File.ReadAllTextAsync(_dataPath);
        var CrewMembers = await _jsonHelper.DeserializeAsync<List<CrewMember>>(json);
        var CrewMember = CrewMembers.FirstOrDefault(a => a.Id == id);
        if (CrewMember != null)
        {
            CrewMembers.Remove(CrewMember);
            var updatedJson = await _jsonHelper.SerializeAsync(CrewMembers);
            await File.WriteAllTextAsync(_dataPath, updatedJson);
        }
    }
}
