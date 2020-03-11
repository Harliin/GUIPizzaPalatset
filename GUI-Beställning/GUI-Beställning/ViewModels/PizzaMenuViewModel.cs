using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Beställning.ViewModels
{
    public class PizzaMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Pizza> Pizzas { get; set; }

        public PizzaMenuViewModel()
        {
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
