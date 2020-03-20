using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;


        #endregion

        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Default Constructor with only Action
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion



        #region Command Methods
        

        /// <summary>
        /// Executes the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }

        /// <summary>
        /// Always returns true
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        #endregion
    }
}
