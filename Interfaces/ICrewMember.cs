namespace AirlinesSystem.Interfaces;

public interface ICrewMember
{
    int Id { get; set; }
    string Name { get; set; }
    string Position { get; set; }
    DateTime DateOfBirth { get; set; }
}
