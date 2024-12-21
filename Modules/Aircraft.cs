
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Aircraft : IAircraft
{
    public int Id { get; set; }
    public string Type { get; set; } = "Undefined";
    public string RegistrationNumber { get; set; } = "Undefined";
    public DateTime YearOfManufacture { get; set; }
    public DateTime LastMaintenance { get; set; }
    public string PhotoPath { get; set; } = "Undefined";
}
