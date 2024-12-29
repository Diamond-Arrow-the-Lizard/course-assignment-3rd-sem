
using System.Text.Json.Serialization;
using AirlinesSystem.Interfaces;
namespace AirlinesSystem.Modules;

public class Ticket : ITicket
{
    public string TicketId { get; } = "Undefined";
    public string FlightCrewId { get; } = "Undefined";
    public string RouteId { get; } = "Undefined";
    public string PassengerName { get; set; } = "Undefined";
    public string SeatNumber { get; set; } = "Undefined";
    public string Class { get; set; } = "Undefined";
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string PassengerPassportSeries { get; set; } = "Undefined";
    public string PassengerPassportNumber { get; set; } = "Undefined";
    public string PassportIssuer { get; set; } = "Undefined";
    public string CashierId { get; } = "Undefined";
    public string CashierName { get; set; } = "Undefined";

    [JsonConstructor]
    public Ticket(string TicketId, string FlightCrewId, string RouteId, string PassengerName, 
    string SeatNumber, string Class, decimal Price, DateTime PurchaseDate, string PassengerPassportSeries, 
    string PassengerPassportNumber,  string PassportIssuer, string CashierId, 
    string CashierName)
    {
        this.TicketId = TicketId;
        this.FlightCrewId= FlightCrewId;
        this.RouteId = RouteId;
        this.PassengerName= PassengerName;
        this.SeatNumber = SeatNumber;
        this.Class = Class;
        this.Price = Price;
        this.PurchaseDate = PurchaseDate;
        this.PassengerPassportSeries= PassengerPassportSeries;
        this.PassengerPassportNumber = PassengerPassportNumber;
        this.PassportIssuer = PassportIssuer;
        this.CashierId = CashierId;
        this.CashierName = CashierName;
    }
}
