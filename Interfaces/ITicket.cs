namespace AirlinesSystem.Interfaces;

public interface ITicket
{
    string TicketId { get; } 
    string FlightCrewId { get; } 
    string RouteId { get; }
    string PassengerName { get; set; }
    string SeatNumber { get; set; }
    string Class { get; set; }
    decimal Price { get; set; }
    DateTime PurchaseDate { get; set; }
    string PassengerPassportSeries { get; set; }
    string PassengerPassportNumber { get; set; }
    DateTime PassportIssueDate { get; set; }
    string PassportIssuer { get; set; }
    string CashierId { get; } 
    string CashierName { get; set; }
}
