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
using AirlinesSystem.Utilities;

namespace AvaloniaApp.ViewModels
{
    public class RouteViewModel : ObservableObject
    {
        private readonly IRouteService _routeService;
        private readonly IServiceProvider _serviceProvider; 
        private Route? _selectedRoute;
        private ObservableCollection<Route> _routes;

        public ObservableCollection<Route> Routes
        {
            get => _routes;
            set => SetProperty(ref _routes, value);
        }

        public Route? SelectedRoute
        {
            get => _selectedRoute;
            set => SetProperty(ref _selectedRoute, value);
        }

        public IAsyncRelayCommand LoadRoutesCommand { get; }
        public IAsyncRelayCommand SelectRouteCommand { get; }

        public RouteViewModel(IRouteService routeService, IServiceProvider serviceProvider)
        {
            _routeService = routeService ?? throw new ArgumentNullException(nameof(routeService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _routes = new ObservableCollection<Route>();

            LoadRoutesCommand = new AsyncRelayCommand(LoadRoutesAsync);
            SelectRouteCommand = new AsyncRelayCommand(SelectRouteAsync);

            LoadRoutesCommand.ExecuteAsync(null);
        }

        private async Task LoadRoutesAsync()
        {
            try
            {
                var routes = await _routeService.GetAllRoutesAsync();
                Routes = new ObservableCollection<Route>(routes.Cast<Route>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading routes: {ex.Message}");
            }
        }

        private async Task SelectRouteAsync()
        {
            await Task.Delay(0);
            if (SelectedRoute != null)
            {
                Console.WriteLine($"Selected route: {SelectedRoute.RouteId}");

                // Используем DI для создания экземпляра TicketViewModel
                var ticketViewModel = _serviceProvider.GetRequiredService<TicketViewModel>();

                ticketViewModel.InputTicket = new Ticket
                (
                    RandomIDGen.GenerateID(5),
                    RandomIDGen.GenerateID(5),
                    SelectedRoute.RouteId,
                    "",
                    "",
                    "",
                    (decimal)10000,
                    DateTime.Now,
                    "",
                    "",
                    "",
                    "C1A12",
                    "Иванова Жанна Ивановна"
                );

                // Переход на TicketView
                var ticketView = new TicketView { DataContext = ticketViewModel };
                var window = new Window { Content = ticketView };
                window.Show();
            }
        }
    }
}
