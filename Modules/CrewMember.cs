
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class CrewMember : ICrewMember
{
    private string name = "";
    private string role = "";

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Role
    {
        get => role;
        set => role = value;
    }
}
