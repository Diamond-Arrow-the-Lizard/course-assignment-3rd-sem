
using System.Text.Json.Serialization;
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class CrewMember : ICrewMember
{
    public string CrewMemberId { get; } = "Undefined";
    public string Name { get; set; } = "Undefined";
    public string Position { get; set; } = "Undefined";
    public DateTime DateOfBirth { get; set; }

    [JsonConstructor]
    public CrewMember(string CrewMemberId, string Name, string Position, DateTime DateOfBirth)
    {
        this.CrewMemberId = CrewMemberId;
        this.Name = Name;
        this.Position = Position;
        this.DateOfBirth = DateOfBirth;
    }
}
