
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using System;

namespace AvaloniaApp.Views;

public partial class TicketView : UserControl
{
    public TicketView()
    {
        InitializeComponent();

        if (Avalonia.Application.Current != null)
            this.DataContext = ((App)Avalonia.Application.Current).GetService<TicketViewModel>();
        else throw new InvalidOperationException("ServiceProvider is not initialized.");
    }
}