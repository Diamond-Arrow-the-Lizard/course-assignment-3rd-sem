using AirlinesSystem.Interfaces;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    /* TODO
    private readonly ITicketService _ticketService;

    public MainWindowViewModel(ITicketService ticketService)
    {
        _ticketService = ticketService;
        SelectedTicketViewModel = new TicketViewModel(_ticketService);
    }

    public TicketViewModel SelectedTicketViewModel { get; }
    */
}
