
using System.Text.Json.Serialization;
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

    [JsonConstructor]
    public Aircraft(string AircraftId, string Type, string RegistrationNumber, DateTime YearOfManufacture, DateTime LastMaintenance, string PhotoPath)
    {
        this.AircraftId = AircraftId;
        this.Type = Type;
        this.RegistrationNumber = RegistrationNumber;
        this.YearOfManufacture = YearOfManufacture;
        this.LastMaintenance = LastMaintenance;
        this.PhotoPath = PhotoPath;
    }

}
