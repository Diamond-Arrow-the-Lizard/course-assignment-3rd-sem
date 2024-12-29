using AvaloniaApp.Views;
using AirlinesSystem.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AvaloniaApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ITicketService _ticketService;

        private object _currentView = new RouteView();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand ShowRouteViewCommand { get; }
        public ICommand ShowTicketListViewCommand { get; }

        public MainWindowViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
            SelectedTicketViewModel = new TicketViewModel(_ticketService);

            ShowRouteViewCommand = new RelayCommand(ShowRouteView);
            ShowTicketListViewCommand = new RelayCommand(ShowTicketListView);
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public TicketViewModel SelectedTicketViewModel { get; }

        private void ShowRouteView() => CurrentView = new RouteView();

        private void ShowTicketListView() => CurrentView = new TicketListView();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // Простой класс RelayCommand для реализации ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler? CanExecuteChanged;

        // Метод, определяющий, можно ли выполнить команду
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _execute();
        }

        // Метод для уведомления об изменении состояния CanExecute
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
