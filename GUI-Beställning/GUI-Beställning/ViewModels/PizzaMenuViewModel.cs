﻿using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using GUI_Beställning.ViewModels.Commands;

namespace GUI_Beställning.ViewModels
{
    public class PizzaMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PizzaMenu";

        public IScreen HostScreen { get; }

        #endregion


        public OrderRepository repo = new OrderRepository();
        //public ObservableCollection<Pizza> _Pizzas { get; set; }

        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public RelayCommand AddPizzaCommand { get; set; }

        PaymentViewModel Payment;
        public PizzaMenuViewModel(IScreen screen = null)
        {
            AddPizzaCommand = new RelayCommand(AddPizzaToOrder);
            //gets hostscreen??
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Pizzas = new ObservableCollection<Pizza>();

            Payment = new PaymentViewModel();
        }

        private ObservableCollection<Pizza> pizzas;

        public ObservableCollection<Pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                var pizzaIE = repo.GetPizzas();
                pizzas = new ObservableCollection<Pizza>(pizzaIE.ToList());
            }
        }


        private void AddPizzaToOrder(object Pizza)
        {
            Pizza pizza = (Pizza)Pizza;
            repo.AddPizzaToOrder(MainWindowViewModel.OrderID, pizza.ID);
            Payment.Foods = new ObservableCollection<object>();
        }
    }

    
}
