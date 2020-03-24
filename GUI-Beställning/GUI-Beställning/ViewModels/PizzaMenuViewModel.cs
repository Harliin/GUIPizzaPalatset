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
        public ObservableCollection<Pizza> Pizzas { get; set; }

        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public RelayCommand AddPizzaCommand { get; set; }
        public PizzaMenuViewModel(IScreen screen = null)
        {
            AddPizzaCommand = new RelayCommand(AddPizzaToOrder);
            //gets hostscreen??
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var PizzaIE = repo.GetPizzas();
            
            Pizzas = new ObservableCollection<Pizza>(PizzaIE.ToList());
            
        }

        private void AddPizzaToOrder(object id)
        {
            repo.AddPizzaToOrder(MainWindowViewModel.OrderID, (int)id);
            MainWindowViewModel.ShowOrder();
        }
    }
}
