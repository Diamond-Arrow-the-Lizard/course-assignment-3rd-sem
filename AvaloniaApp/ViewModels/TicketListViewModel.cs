using CommunityToolkit.Mvvm.ComponentModel;
using AirlinesSystem.Modules;
using AirlinesSystem.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace AvaloniaApp.ViewModels
{
    public class TicketListViewModel : ObservableObject
    {
        private readonly ITicketService _ticketService;

        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public TicketListViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
            LoadTickets();
        }

        private async void LoadTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();

            foreach (var ticket in tickets.OfType<Ticket>())
            {
                Tickets.Add(ticket);
            }
        }

    }
}
