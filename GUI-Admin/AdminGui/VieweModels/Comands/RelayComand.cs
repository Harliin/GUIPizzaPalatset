using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AdminGui
{
   public class RelayComand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Funktion.Invoke(parameter);

        }
        public RelayComand(Action<object> action)
        {
            Funktion = action;
        }
        private Action<object> Funktion;

        
    }
}
