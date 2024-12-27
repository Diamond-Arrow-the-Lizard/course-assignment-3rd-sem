
using AirlinesSystem.Services;
using AirlinesSystem.Utilities;
using Avalonia.Controls;
using AvaloniaApp.ViewModels;

namespace AvaloniaApp.Views;

public partial class TicketView : UserControl 
{
    public TicketView()
    {
        InitializeComponent();
        this.DataContext = new TicketViewModel(new TicketService(new JsonHelper()));
    }
}