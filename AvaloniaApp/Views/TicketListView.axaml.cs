
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
using AirlinesSystem.Modules;
using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using System;

namespace AvaloniaApp.Views;

public partial class TicketListView : UserControl
{
    public TicketListView()
    {
        InitializeComponent();

        if (Avalonia.Application.Current != null)
            this.DataContext = ((App)Avalonia.Application.Current).GetService<TicketListViewModel>();
        else throw new InvalidOperationException("ServiceProvider is not initialized.");
    }
}