
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

class Aircraft : IAircraft
{
    private string aircraftType = "";
    private string registrationNumber = "";
    private int yearOfManufacture;
    private string photoPath = "";
    private DateTime lastInspectionDate;

    public string AircraftType
    {
        get => aircraftType;
        set => aircraftType = value;
    }

    public string RegistrationNumber
    {
        get => registrationNumber;
        set => registrationNumber = value;
    }

    public int YearOfManufacture
    {
        get => yearOfManufacture;
        set => yearOfManufacture = value;
    }

    public string PhotoPath
    {
        get => photoPath;
        set => photoPath = value;
    }

    public DateTime LastInspectionDate
    {
        get => lastInspectionDate;
        set => lastInspectionDate = value;
    }
}
