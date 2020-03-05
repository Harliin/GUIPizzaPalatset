using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Fires when CanExecute is changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Command Variables
        /// </summary>
        #region Variables
        public Action<object> action;
        public Predicate<object> _CanBeExecuted;
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="_action"></param>
        /// <param name="_predicate"></param>
        public RelayCommand(Action<object> _action, Predicate<object> _predicate)
        {

            this.action = _action;

            this._CanBeExecuted = _predicate;
        }
        /// <summary>
        /// If command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => _CanBeExecuted.Invoke(parameter);

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => action.Invoke(parameter);
    }
}
