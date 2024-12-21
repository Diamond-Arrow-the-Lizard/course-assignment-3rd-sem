namespace AirlinesSystem.Interfaces;

public interface ITicket
{
    int TicketId { get; set; }
    int FlightId { get; set; }
    string PassengerName { get; set; }
    string SeatNumber { get; set; }
    string Class { get; set; }
    decimal Price { get; set; }
    DateTime PurchaseDate { get; set; }
    string PassengerPassportSeries { get; set; }
    string PassengerPassportNumber { get; set; }
    DateTime PassportIssueDate { get; set; }
    string PassportIssuer { get; set; }
    int CashierId { get; set; }
    string CashierName { get; set; }
}
