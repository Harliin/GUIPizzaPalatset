using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Kassörska.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> _action;

        private Predicate<object> _condition;

        public RelayCommand(Action<object> action, Predicate<object> condition)
        {
            _action = action;
            _condition = condition;
        }

        public RelayCommand(Action<object> action)
            : this(action, null)
        {
            
        }

        public bool CanExecute(object parameter)
        {
            if(_condition == null)
            {
                return true;
            }

            return _condition(parameter);
        }

        public void Execute(object parameter) => _action.Invoke(parameter);
    }
}
