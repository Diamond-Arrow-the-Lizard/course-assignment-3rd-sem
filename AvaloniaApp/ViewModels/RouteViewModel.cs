using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AirlinesSystem.Modules;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AvaloniaApp.ViewModels
{
    public class RouteViewModel : ObservableObject
    {
        private readonly IRouteService _routeService;
        private Route? _selectedRoute;

        public ObservableCollection<Route> Routes { get; } = new();  // изменили на Route
        public Route? SelectedRoute
        {
            get => _selectedRoute;
            set => SetProperty(ref _selectedRoute, value);
        }

        public IAsyncRelayCommand LoadRoutesCommand { get; }
        public IAsyncRelayCommand SelectRouteCommand { get; }

        public RouteViewModel(IRouteService routeService)
        {
            _routeService = routeService ?? throw new ArgumentNullException(nameof(routeService));
            LoadRoutesCommand = new AsyncRelayCommand(LoadRoutesAsync);
            SelectRouteCommand = new AsyncRelayCommand(SelectRouteAsync);
        }

        private async Task LoadRoutesAsync()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            Routes.Clear();
            foreach (var route in routes)
            {
                Routes.Add((Route)route);  // Приведение к Route
            }
        }

        private async Task SelectRouteAsync()
        {
            if (SelectedRoute != null)
            {
                // Логика перехода к TicketView
                Console.WriteLine($"Route selected: {SelectedRoute.RouteId}");
            }
        }
    }
}
