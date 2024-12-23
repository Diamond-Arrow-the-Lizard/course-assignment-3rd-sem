
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Aircraft : IAircraft
{
    public string AircraftId { get; } = "Undefined";
    public string Type { get; set; } = "Undefined";
    public string RegistrationNumber { get; set; } = "Undefined";
    public DateTime YearOfManufacture { get; }
    public DateTime LastMaintenance { get; set; }
    public string PhotoPath { get; set; } = "Undefined";
}
