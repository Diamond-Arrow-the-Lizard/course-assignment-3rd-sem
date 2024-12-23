
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Ticket : ITicket
{
    public string TicketId { get; } = "Undefined";
    public string FlightCrewId { get; } = "Undefined";
    public string PassengerName { get; set; } = "Undefined";
    public string SeatNumber { get; set; } = "Undefined";
    public string Class { get; set; } = "Undefined";
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string PassengerPassportSeries { get; set; } = "Undefined";
    public string PassengerPassportNumber { get; set; } = "Undefined";
    public DateTime PassportIssueDate { get; set; }
    public string PassportIssuer { get; set; } = "Undefined";
    public string CashierId { get; } = "Undefined";
    public string CashierName { get; set; } = "Undefined";
}
