using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

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

        var command = new ReactiveCommand();
        public PizzaMenuViewModel(IScreen screen = null)
        {
            
            //gets hostscreen??
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var PizzaIE = repo.GetPizzas();
            
            Pizzas = new ObservableCollection<Pizza>(PizzaIE.ToList());
            
        }

    }
}
