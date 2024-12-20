
namespace AirlinesSystem.Interfaces;

public interface ICrewMemberService
{
    void AddCrewMember(ICrewMember crewMember);
    void UpdateCrewMember(ICrewMember crewMember);
    void RemoveCrewMember(string name);
    ICrewMember GetCrewMember(string name);
    List<ICrewMember> GetAllCrewMembers();
}
