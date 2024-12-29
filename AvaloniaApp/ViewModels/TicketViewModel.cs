using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Modules;
using AirlinesSystem.Services;
using Avalonia.Controls;

namespace AvaloniaApp.ViewModels
{
    public class TicketViewModel : ObservableObject
    {
        public IAsyncRelayCommand SaveCommand { get; }
        private readonly ITicketService _ticketService;
        private Ticket? _ticket = new Ticket(
            "A000",
            "B000",
            "123",
            "",
            "",
            "",
            (decimal)10000,
            DateTime.Now,
            "",
            "",
            DateTime.MinValue,
            "",
            "C100",
            "Anna"
        );

        public Ticket? InputTicket
        {
            get => _ticket;
            set => SetProperty(ref _ticket, value);
        }

        public TicketViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
            SaveCommand = new AsyncRelayCommand(SaveChangesAsync);
        }


        private async Task SaveChangesAsync()
        {
            if (InputTicket != null)
            {
                Ticket FormattedTicket = new Ticket
                (
                   InputTicket.TicketId,
                   InputTicket.FlightCrewId,
                   InputTicket.RouteId,
                   InputTicket.PassengerName,
                   InputTicket.SeatNumber,
                   InputTicket.Class,
                   InputTicket.Price,
                   InputTicket.PurchaseDate,
                   InputTicket.PassengerPassportSeries,
                   InputTicket.PassengerPassportNumber,
                   InputTicket.PassportIssueDate,
                   InputTicket.PassportIssuer,
                   InputTicket.CashierId,
                   InputTicket.CashierName
                );

                await _ticketService.AddTicketAsync(FormattedTicket);
                Console.WriteLine("Ticket saved");
            }
            else
            {
                Console.WriteLine("Ticket was null, nothing saved");
            }
        }
    }
}
