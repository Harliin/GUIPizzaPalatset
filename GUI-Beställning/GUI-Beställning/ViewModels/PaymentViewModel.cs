﻿using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class PaymentViewModel : ReactiveObject, IRoutableViewModel
    {
        public OrderRepository repo = new OrderRepository();
        public static MainWindowViewModel MainWindowViewModel;

        #region For Reactive UI
        public string UrlPathSegment => "PaymentMenu";

        public IScreen HostScreen { get; }
        #endregion
        public Order CurrentOrder { get; set; }
        public ObservableCollection<object> Foods => MainWindowViewModel.Order;


        public RelayCommand RemoveCommand { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public int OrderID => MainWindowViewModel.OrderID;
        public PaymentViewModel(MainWindowViewModel viewModel = null,IScreen screen = null)
        {
            RemoveCommand = new RelayCommand(RemoveFoodFromOrder);

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

    
        /// <summary>
        /// Method To remove Food From a Order
        /// </summary>
        /// <param name="parameter"></param>
        public void RemoveFoodFromOrder(object parameter)
        {
            var Type = parameter.GetType();

            if (Type == typeof(Pizza))
            {
                Pizza pizza = (Pizza)parameter;
                repo.RemovePizzaFromOrder(OrderID, pizza.ID);
            }
            else if(Type == typeof(Pasta))
            {
                Pasta pasta = (Pasta)parameter;
                repo.RemovePastaFromOrder(OrderID, pasta.ID);
            }
            else if (Type == typeof(Sallad))
            {
                Sallad sallad = (Sallad)parameter;
                repo.RemoveSalladFromOrder(OrderID, sallad.ID);
            }
            else if (Type == typeof(Drink))
            {
                Drink drink = (Drink)parameter;
                repo.RemoveDrinkFromOrder(OrderID, drink.ID);
            }
            else if (Type == typeof(Extra))
            {
                Extra extra = (Extra)parameter;
                repo.RemoveExtraFromOrder(OrderID, extra.ID);
            }
            MainWindowViewModel.OrderChanged();
            
        }
    }

}
