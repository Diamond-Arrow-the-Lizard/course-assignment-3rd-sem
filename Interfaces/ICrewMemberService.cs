
namespace AirlinesSystem.Interfaces;

public interface ICrewMemberService
{
    Task<IEnumerable<ICrewMember>> GetAllCrewMembersAsync();
    Task<ICrewMember> GetCrewMemberByIdAsync(int id);
    Task AddCrewMemberAsync(ICrewMember crewMember);
    Task RemoveCrewMemberAsync(int id);
}
