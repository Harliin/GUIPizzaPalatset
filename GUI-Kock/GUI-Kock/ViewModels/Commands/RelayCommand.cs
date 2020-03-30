﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GUI_Kock.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// The action to run
        /// </summary>
        private Action _Action;

        //Lägg till senare
        //private Predicate<object> _CanBeExecuted;



        #endregion

        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Default Constructor with only Action
        public RelayCommand(Action action) //Lägg till senare när knappen fungerar -> Predicate CanExecute
        {
            // Set command action
            this._Action = action;

            // Set command conditions
            //Lägg till när knappen fungerar
            //this._CanBeExecuted = CanExecute;
        }
        #endregion



        #region Command Methods


        /// <summary>
        /// Executes the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //_Action(parameter);
            Execute(_Action);
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
