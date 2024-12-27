using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using System;

namespace AvaloniaApp.Views
{
    public partial class RouteView : UserControl
    {
        public RouteView()
        {
            InitializeComponent();
            if (Avalonia.Application.Current != null)
                this.DataContext = ((App)Avalonia.Application.Current).GetService<RouteViewModel>();
            else throw new InvalidOperationException("ServiceProvider is not initialized.");
        }
    }
}
