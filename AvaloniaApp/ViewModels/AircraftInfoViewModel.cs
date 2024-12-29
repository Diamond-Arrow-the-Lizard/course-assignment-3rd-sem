using AirlinesSystem.Interfaces;
using AirlinesSystem.Modules;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

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

        public AircraftInfoViewModel(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService ?? throw new ArgumentNullException(nameof(aircraftService));
        }

        public async void LoadAircraftInfo(string aircraftId)
        {
            if (string.IsNullOrEmpty(aircraftId)) return;
            Aircraft = (Aircraft)await _aircraftService.GetAircraftByIdAsync(aircraftId);
        }
    }
}
