using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Kock.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the CustomerUpdateCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
       
            public Predicate<object> Predicate { get; set; }
        public Action<object> Action { get; set; }
        public RelayCommand(Action<object> action)
        {
            Action = action;
        }

        private LoginViewModel viewModel;

        #region ICommand members

        public event EventHandler CanExecuteChanged = (sender, e) => { };


        public bool CanExecute(object parameter)
        {
            //return viewModel.CheckUser();
            return true;
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        #endregion
    }
}
