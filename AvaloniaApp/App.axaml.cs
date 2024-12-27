using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaApp.ViewModels;
using AvaloniaApp.Views;
using AirlinesSystem.Utilities;
using AirlinesSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using AirlinesSystem.Interfaces;
using System;

namespace AvaloniaApp;

public partial class App : Application
{
    private ServiceProvider? _serviceProvider;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider() ?? throw new NullReferenceException("Service Provider is null");

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Устанавливаем DataContext для MainWindow
            desktop.MainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<IJsonHelper, JsonHelper>();
        services.AddSingleton<IAircraftService, AircraftService>();
        services.AddSingleton<IRouteService, RouteService>();
        services.AddSingleton<ITicketService, TicketService>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<TicketView>();
        services.AddSingleton<TicketViewModel>();
    }
}