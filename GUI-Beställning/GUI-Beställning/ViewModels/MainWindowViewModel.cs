﻿using GUI_Beställning.ViewModels.Commands;
using GUI_Beställning.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        #region Commands
        public ReactiveCommand<Unit, IRoutableViewModel> PizzaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> PastaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> SalladMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> DrinkMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ExtraMenu { get; }

        #endregion


        public MainWindowViewModel()
        {
            Router = new RoutingState();

            Locator.CurrentMutable.Register(() => new PizzaMenuView(), typeof(IViewFor<PizzaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PastaMenuView(), typeof(IViewFor<PastaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new SalladMenuView(), typeof(IViewFor<SalladMenuViewModel>));

            Locator.CurrentMutable.Register(() => new DrinkMenuView(), typeof(IViewFor<DrinkMenuViewModel>));

            Locator.CurrentMutable.Register(() => new ExtraMenuView(), typeof(IViewFor<ExtraMenuViewModel>));



            PizzaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PizzaMenuViewModel()));

            PastaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PastaMenuViewModel()));

            SalladMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SalladMenuViewModel()));

            DrinkMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new DrinkMenuViewModel()));

            ExtraMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ExtraMenuViewModel()));

        }
    }
}
