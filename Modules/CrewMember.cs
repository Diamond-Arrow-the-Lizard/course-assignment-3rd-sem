
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class CrewMember : ICrewMember
{
    public int Id { get; set; }
    public string Name { get; set; } = "Undefined";
    public string Position { get; set; } = "Undefined";
    public DateTime DateOfBirth { get; set; }
}
