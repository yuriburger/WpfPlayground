using System;
using System.Threading.Tasks;
using System.Windows.Input;

// An AsyncRelayCommand is the awaitable version of a RelayCommand
namespace WpfApp1.Commands;

public class AsyncRelayCommand : ICommand
{
    private readonly Predicate<object> _canExecute;
    private readonly Func<object, Task> _execute;

    public AsyncRelayCommand(Func<object, Task> execute, Predicate<object> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    // Note that this is an async void which is not recommended but is used here for simplicity
    public async void Execute(object parameter)
    {
        await ExecuteAsync(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    private async Task ExecuteAsync(object parameter)
    {
        await _execute(parameter);
    }
}