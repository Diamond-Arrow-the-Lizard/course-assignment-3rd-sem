namespace AirlinesSystem.Interfaces;

public interface ICrewMember
{
    string CrewMemberId { get; } 
    string Name { get; set; }
    string Position { get; set; }
    DateTime DateOfBirth { get; set; }
}
