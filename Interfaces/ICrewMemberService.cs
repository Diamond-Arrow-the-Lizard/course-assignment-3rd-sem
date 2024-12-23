
namespace AirlinesSystem.Interfaces;

public interface ICrewMemberService
{
    Task<IEnumerable<ICrewMember>> GetAllCrewMembersAsync();
    Task<ICrewMember> GetCrewMemberByIdAsync(string id);
    Task AddCrewMemberAsync(ICrewMember crewMember);
    Task RemoveCrewMemberAsync(string id);
}
