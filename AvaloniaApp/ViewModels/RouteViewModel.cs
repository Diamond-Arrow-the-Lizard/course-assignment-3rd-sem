using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AirlinesSystem.Modules;
using AirlinesSystem.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System;

namespace AvaloniaApp.ViewModels
{
    public class RouteViewModel : ObservableObject
    {
        private readonly IRouteService _routeService;
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

        public RouteViewModel(IRouteService routeService)
        {
            _routeService = routeService ?? throw new ArgumentNullException(nameof(routeService));
            _routes = new ObservableCollection<Route>();

            LoadRoutesCommand = new AsyncRelayCommand(LoadRoutesAsync);
            SelectRouteCommand = new AsyncRelayCommand(SelectRouteAsync);

            LoadRoutesCommand.ExecuteAsync(null);
            SelectRouteCommand.ExecuteAsync(null);
        }

        private async Task LoadRoutesAsync()
        {
            try
            {
                var routes = await _routeService.GetAllRoutesAsync();
                Routes = new ObservableCollection<Route>(
                    routes.Cast<Route>()); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading routes: {ex.Message}");
            }
        }

        private async Task SelectRouteAsync()
        {
            if (SelectedRoute != null)
            {
                await Task.Delay(100); 
                Console.WriteLine($"Selected route: {SelectedRoute.RouteId}");
            }
        }
    }
}
