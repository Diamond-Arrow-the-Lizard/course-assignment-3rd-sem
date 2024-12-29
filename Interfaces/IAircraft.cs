namespace AirlinesSystem.Interfaces;

public interface IAircraft
{
    string AircraftId { get; }
    string FlightCrewId { get;}
    string Type { get; set; }
    string RegistrationNumber { get; set; }
    DateTime YearOfManufacture { get; }
    DateTime LastMaintenance { get; set; }
    string PhotoPath { get; set; }
}
