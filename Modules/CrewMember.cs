
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class CrewMember : ICrewMember
{
    public string CrewMemberId { get; } = "Undefined";
    public string Name { get; set; } = "Undefined";
    public string Position { get; set; } = "Undefined";
    public DateTime DateOfBirth { get; set; }
}
