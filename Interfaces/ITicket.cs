namespace AirlinesSystem.Interfaces;

public interface ITicket
{
    string FlightNumber { get; set; }
    DateTime DepartureDate { get; set; }
    DateTime ArrivalDate { get; set; }
    string SeatNumber { get; set; }
    string Class { get; set; }
    string PassengerName { get; set; }
    string PassportNumber { get; set; }
    DateTime PassportIssueDate { get; set; }
    string PassportIssuer { get; set; }
    DateTime PurchaseDate { get; set; }
    decimal Price { get; set; }
    string CashierName { get; set; }
    string CashierId { get; set; }
}
