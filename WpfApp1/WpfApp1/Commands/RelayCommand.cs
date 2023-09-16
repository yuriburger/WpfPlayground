using System;
using System.Windows.Input;

// A RelayCommand in WPF is used to be able to bind different commands to the same method.
// This way we avoid repeating code for command handling in different parts of the application,
// which can make the code more maintainable and less complex.
namespace WpfApp1.Commands;

public class RelayCommand : ICommand
{
    private readonly Func<object, bool> _canExecute;
    private readonly Action<object> _execute;

    public RelayCommand(Action<object> execute, Func<object, bool> func)
    {
        _execute = execute;
        _canExecute = func;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}