using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AirlinesSystem.Modules;
using AirlinesSystem.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using AvaloniaApp.Views;

namespace AvaloniaApp.ViewModels
{
    public class TicketListViewModel : ObservableObject
    {
        private readonly ITicketService _ticketService;
        private readonly IServiceProvider _serviceProvider;

        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public Ticket? SelectedTicket { get; set; }

        // Команда для открытия информации о самолёте
        public IAsyncRelayCommand ShowAircraftInfoCommand { get; }

        public TicketListViewModel(ITicketService ticketService, IServiceProvider serviceProvider)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ShowAircraftInfoCommand = new AsyncRelayCommand(OpenAircraftInfoWindow);
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

        private async Task OpenAircraftInfoWindow()
        {
            await Task.Delay(0);
            if (SelectedTicket == null) return;

            var aircraftInfoViewModel = _serviceProvider.GetRequiredService<AircraftInfoViewModel>();
            await aircraftInfoViewModel.LoadAircraftInfoAsync(SelectedTicket.AircraftId);

            var aircraftInfoView = new AircraftInfoView
            {
                DataContext = aircraftInfoViewModel
            };

            var window = new Window
            {
                Content = aircraftInfoView,
                Title = "Информация о самолёте",
                Width = 800,
                Height = 600
            };

            window.Show();
        }
    }
}
