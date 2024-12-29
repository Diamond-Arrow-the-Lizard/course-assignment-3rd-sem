
using System.Text.Json.Serialization;
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class CrewMember : ICrewMember
{
    public string CrewMemberId { get; } = "Undefined";
    public string Name { get; set; } = "Undefined";

    [JsonConstructor]
    public CrewMember(string CrewMemberId, string Name)
    {
        this.CrewMemberId = CrewMemberId;
        this.Name = Name;
    }
}
