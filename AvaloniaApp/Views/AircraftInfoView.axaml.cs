using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
using AirlinesSystem.Modules;
using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using System;

namespace AvaloniaApp.Views;

public partial class AircraftInfoView : UserControl
{
    public AircraftInfoView()
    {
        InitializeComponent();

        if (Avalonia.Application.Current != null)
            this.DataContext = ((App)Avalonia.Application.Current).GetService<AircraftInfoViewModel>();
        else throw new InvalidOperationException("ServiceProvider is not initialized.");
    }
}