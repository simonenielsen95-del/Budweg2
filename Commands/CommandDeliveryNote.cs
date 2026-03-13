using Budweg2._0.Models;
using Budweg2._0.Repository;
using Budweg2._0.VievModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Budweg2._0.Commands
{
    internal class CommandDeliveryNote : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    public CommandDeliveryNote(Action<object> execute, Predicate<object> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }
    

    
        


    }
}
