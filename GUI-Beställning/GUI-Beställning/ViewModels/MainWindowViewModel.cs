﻿using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using GUI_Beställning.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public OrderRepository repo = new OrderRepository();
        public RoutingState Router { get; }
        public List<string> CurOrder { get; set; }
        public Order CurrentOrder { get; set; }
        public ObservableCollection<string> OrderNames { get; set; }
        public int OrderID { get; set; }

        #region Commands
        public ReactiveCommand<Unit, IRoutableViewModel> PizzaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> PastaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> SalladMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> DrinkMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ExtraMenu { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> PaymentMenu { get; }

        #endregion


        public MainWindowViewModel()
        {
            OrderID = 124;

            Router = new RoutingState();

            Locator.CurrentMutable.Register(() => new PizzaMenuView(), typeof(IViewFor<PizzaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PastaMenuView(), typeof(IViewFor<PastaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new SalladMenuView(), typeof(IViewFor<SalladMenuViewModel>));

            Locator.CurrentMutable.Register(() => new DrinkMenuView(), typeof(IViewFor<DrinkMenuViewModel>));

            Locator.CurrentMutable.Register(() => new ExtraMenuView(), typeof(IViewFor<ExtraMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PaymentView(), typeof(IViewFor<PaymentViewModel>));



            PizzaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PizzaMenuViewModel()));

            PastaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PastaMenuViewModel()));

            SalladMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SalladMenuViewModel()));

            DrinkMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new DrinkMenuViewModel()));

            ExtraMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ExtraMenuViewModel()));

            PaymentMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PaymentViewModel()));
            ShowOrder();
        }

        public void ShowOrder()
        {
            CurOrder = new List<string>();
            var ordersIE = repo.ShowOrderByID(this.OrderID);
            //this.CurrentOrder = new ObservableCollection<Order>(ordersIE.ToList());
            var temp = ordersIE.ToList();

            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { CurOrder.Add(pizza.Name); });
            CurrentOrder.pasta.ForEach(pasta => { CurOrder.Add(pasta.Name); });
            CurrentOrder.sallad.ForEach(sallad => { CurOrder.Add(sallad.Name); });
            CurrentOrder.drink.ForEach(drink => { CurOrder.Add(drink.Name); });
            CurrentOrder.extra.ForEach(extra => { CurOrder.Add(extra.Name); });
            
            //List<Pizza> pizza = new List<Pizza>();
            //  pizza.Add(CurrentOrder.Select(x => x.pizza));

            //foreach (var food in ordersIE)
            //{
            //    foreach (var fooditem in food.pizza)
            //    {
            //        this.OrderNames.Add(fooditem.Name.ToString());
            //    }
            //    foreach (var fooditem in food.pasta)
            //    {
            //        this.OrderNames.Add(fooditem.Name.ToString());
            //    }
            //    foreach (var fooditem in food.sallad)
            //    {
            //        this.OrderNames.Add(fooditem.Name.ToString());
            //    }
            //    foreach (var fooditem in food.drink)
            //    {
            //        this.OrderNames.Add(fooditem.Name.ToString());
            //    }
            //    foreach (var fooditem in food.extra)
            //    {
            //        this.OrderNames.Add(fooditem.Name.ToString());
            //    }
            //}
        }
    }
}
