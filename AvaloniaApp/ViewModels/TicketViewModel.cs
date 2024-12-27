using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AirlinesSystem.Interfaces;
using AirlinesSystem.Modules;
using AirlinesSystem.Services;

namespace AvaloniaApp.ViewModels
{
    public class TicketViewModel : ObservableObject
    {
        private readonly ITicketService _ticketService;
        private Ticket? _ticket;

        // Конструктор для инициализации сервиса билетов и команды
        public TicketViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
            SaveCommand = new AsyncRelayCommand(SaveChangesAsync);
        }

        // Свойство для работы с моделью Ticket
        public Ticket? Ticket
        {
            get => _ticket;
            set => SetProperty(ref _ticket, value);
        }

        // Команда для сохранения изменений
        public IAsyncRelayCommand SaveCommand { get; }

        // Асинхронный метод для сохранения изменений
        private async Task SaveChangesAsync()
        {
            if (Ticket != null)
            {
                await _ticketService.AddTicketAsync(Ticket);
                // Дополнительная логика, например, уведомление пользователя
                Console.WriteLine("Ticket saved");
            }
            else 
            {
                Console.WriteLine("Ticket was null, nothing saved");
            }
        }
    }
}
