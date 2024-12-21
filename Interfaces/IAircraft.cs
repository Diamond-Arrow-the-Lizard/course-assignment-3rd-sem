namespace AirlinesSystem.Interfaces;

public interface IAircraft
{
    int Id { get; set; }
    string Type { get; set; }
    string RegistrationNumber { get; set; }
    DateTime YearOfManufacture { get; set; }
    DateTime LastMaintenance { get; set; }
    string PhotoPath { get; set; }
}
