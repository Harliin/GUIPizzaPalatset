using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

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

        public PizzaMenuViewModel(IScreen screen = null)
        {
            //gets hostscreen??
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Pizzas = new ObservableCollection<Pizza>();
            GetPizzas();
        }

        public void GetPizzas()
        {
            for (int i = 0; i < 10; i++)
            {
                Pizza pizza = new Pizza();
                pizza.ID = i+1;
                pizza.Name = "Vesuvio";
                pizza.Price = 90;
                Pizzas.Add(pizza);
            }
        }

    }
}
