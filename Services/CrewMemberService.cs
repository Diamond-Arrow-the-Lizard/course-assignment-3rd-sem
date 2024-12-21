
namespace AirlinesSystem.Services;

public class CrewMemberService : ICrewMemberService
{
    private readonly IJsonHelper _jsonHelper;
    public CrewMemberService(IJsonHelper jsonHelper)
    {
        _jsonHelper = jsonHelper;
    }
    public async Task<IEnumerable<ICrewMember>> GetAllCrewMembersAsync()
    {
        var json = await File.ReadAllTextAsync("crewMember.json");
        return await _jsonHelper.DeserializeAsync<List<ICrewMember>>(json);
    }
    public async Task<ICrewMember> GetCrewMemberByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync("crewMember.json");
        var members = await _jsonHelper.DeserializeAsync<List<ICrewMember>>(json);
        return members.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Crew member wasn't found"); // Такой x, чей ID соот. искомому
    }
    public async Task AddCrewMemberAsync(ICrewMember crewMember)
    {
        var json = await File.ReadAllTextAsync("crewMember.json");
        var crewMembers = await _jsonHelper.DeserializeAsync<List<ICrewMember>>(json);
        crewMembers.Add(crewMember);
        var updatedJson = await _jsonHelper.SerializeAsync(crewMembers);
        await File.WriteAllTextAsync("crewMember.json", updatedJson);

    }
    public async Task RemoveCrewMemberAsync(int id)
    {
        var json = await File.ReadAllTextAsync("crewMember.json");
        var members = await _jsonHelper.DeserializeAsync<List<ICrewMember>>(json);
        var crewMember = members.FirstOrDefault(x => x.Id == id); // Такой x, чей ID соот. искомому
        if (crewMember != null)
        {
            members.Remove(crewMember);
            var updatedJson = await _jsonHelper.SerializeAsync(members);
            await File.WriteAllTextAsync("crewMember.json", updatedJson);
        }

    }
}