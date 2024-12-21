
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Ticket : ITicket
{
    public int TicketId { get; set; }
    public int FlightId { get; set; }
    public string PassengerName { get; set; } = "Undefined";
    public string SeatNumber { get; set; } = "Undefined";
    public string Class { get; set; } = "Undefined";
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string PassengerPassportSeries { get; set; } = "Undefined";
    public string PassengerPassportNumber { get; set; } = "Undefined";
    public DateTime PassportIssueDate { get; set; }
    public string PassportIssuer { get; set; } = "Undefined";
    public int CashierId { get; set; }
    public string CashierName { get; set; } = "Undefined";
}
