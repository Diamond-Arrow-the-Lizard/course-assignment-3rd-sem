using AirlinesSystem.Interfaces;
using AirlinesSystem.Modules;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace AvaloniaApp.ViewModels
{
    public class AircraftInfoViewModel : ObservableObject
    {
        private readonly IAircraftService _aircraftService;
        private Aircraft? _aircraft;
        public Aircraft? Aircraft
        {
            get => _aircraft;
            set => SetProperty(ref _aircraft, value);
        }
        public string? AircraftPhotoPath => Aircraft?.PhotoPath;

        public AircraftInfoViewModel(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService ?? throw new ArgumentNullException(nameof(aircraftService));
        }

        public async Task LoadAircraftInfoAsync(string aircraftId)
        {
            if (string.IsNullOrEmpty(aircraftId)) return;

            try
            {
                var aircraftInterface = await _aircraftService.GetAircraftByIdAsync(aircraftId);

                if (aircraftInterface is not Aircraft aircraft)
                {
                    Console.WriteLine("Aircraft not found or incorrect type.");
                    return;
                }
                Aircraft = aircraft;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading aircraft info: {ex.Message}");
            }
        }
    }
}
