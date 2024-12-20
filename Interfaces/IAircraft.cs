namespace AirlinesSystem.Interfaces;

public interface IAircraft
{
    public string AircraftType { get; set; }
    public string RegistrationNumber { get; set; }
    public int YearOfManufacture { get; set; }
    public string PhotoPath { get; set; }
    public DateTime LastInspectionDate { get; set; }
}
