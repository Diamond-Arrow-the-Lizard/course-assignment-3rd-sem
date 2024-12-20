
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

class Ticket : ITicket
{
    private string flightNumber = "";
    private DateTime departureDate;
    private DateTime arrivalDate;
    private string seatNumber = "";
    private string ticketClass = "";
    private string passengerName = "";
    private string passportNumber = "";
    private DateTime passportIssueDate;
    private string passportIssuer = "";
    private DateTime purchaseDate;
    private decimal price;
    private string cashierName = "";
    private string cashierId = "";

    public string FlightNumber
    {
        get => flightNumber;
        set => flightNumber = value;
    }

    public DateTime DepartureDate
    {
        get => departureDate;
        set => departureDate = value;
    }

    public DateTime ArrivalDate
    {
        get => arrivalDate;
        set => arrivalDate = value;
    }

    public string SeatNumber
    {
        get => seatNumber;
        set => seatNumber = value;
    }

    public string Class
    {
        get => ticketClass;
        set => ticketClass = value;
    }

    public string PassengerName
    {
        get => passengerName;
        set => passengerName = value;
    }

    public string PassportNumber
    {
        get => passportNumber;
        set => passportNumber = value;
    }

    public DateTime PassportIssueDate
    {
        get => passportIssueDate;
        set => passportIssueDate = value;
    }

    public string PassportIssuer
    {
        get => passportIssuer;
        set => passportIssuer = value;
    }

    public DateTime PurchaseDate
    {
        get => purchaseDate;
        set => purchaseDate = value;
    }

    public decimal Price
    {
        get => price;
        set => price = value;
    }

    public string CashierName
    {
        get => cashierName;
        set => cashierName = value;
    }

    public string CashierId
    {
        get => cashierId;
        set => cashierId = value;
    }
}
