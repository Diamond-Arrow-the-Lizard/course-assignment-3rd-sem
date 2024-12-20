
namespace AirlinesSystem.Interfaces;

public interface ITicketService
{
    void AddTicket(ITicket ticket);
    void UpdateTicket(ITicket ticket);
    void RemoveTicket(string flightNumber, string seatNumber, DateTime departureDate);
    ITicket GetTicket(string flightNumber, string seatNumber, DateTime departureDate);
    List<ITicket> GetAllTickets();
    List<ITicket> GetTicketsByPassenger(string passportNumber);
}
