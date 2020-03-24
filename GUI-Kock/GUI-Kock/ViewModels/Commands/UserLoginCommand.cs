using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Kock.ViewModels.Commands
{
    public class UserLoginCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the CustomerUpdateCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
        public UserLoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private LoginViewModel viewModel;

        #region ICommand members

        public event EventHandler CanExecuteChanged = (sender, e) => { };


        public bool CanExecute(object parameter)
        {
            return viewModel.CheckUser();
        }

        public void Execute(object parameter)
        {
            viewModel.Login();
        }

        #endregion
    }
}
