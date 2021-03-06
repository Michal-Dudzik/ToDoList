using System;
using System.Windows.Input;

namespace ToDoList.Core
{
    public class RelayCommand : ICommand
    {
        // private Action<object> _execute;
        // private Func<object, bool> _canExecute;
        // public event EventHandler CanExecuteChanged
        // {
        //     add => CommandManager.RequerySuggested += value;
        //     remove => CommandManager.RequerySuggested -= value;
        // }
        // public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        // {
        //     _execute = execute;
        //     _canExecute = canExecute;
        // }
        // public bool CanExecute(object parameter)
        // {
        //     return _canExecute == null || _canExecute(parameter);
        //     // return true;
        // }
        // public void Execute(object parameter)
        // {
        //     _execute(parameter);
        // }
        
        private Action mAction;
        
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        
        public event EventHandler CanExecuteChanged;
        
        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
