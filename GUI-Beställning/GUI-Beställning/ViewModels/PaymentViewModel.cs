using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class PaymentViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PaymentMenu";

        public IScreen HostScreen { get; }
        #endregion
        public Order CurrentOrder { get; set; }
        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<object> Foods { get; set; }

        public RelayCommand RemoveCommand { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public int OrderID { get; set; }
        public PaymentViewModel(IScreen screen = null)
        {
            RemoveCommand = new RelayCommand(RemoveFoodFromOrder);
            OrderID = 125;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            ShowOrder();
            
        }

        public void ShowOrder()
        {
            Foods = new ObservableCollection<object>();

            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            CurrentOrder = temp[0];

            CurrentOrder.pizza.ForEach(pizza => { Foods.Add(pizza); });
            CurrentOrder.pasta.ForEach(pasta => { Foods.Add(pasta); });
            CurrentOrder.sallad.ForEach(sallad => { Foods.Add(sallad); });
            CurrentOrder.drink.ForEach(drink => { Foods.Add(drink); });
            CurrentOrder.extra.ForEach(extra => { Foods.Add(extra); });


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
            
        }

        public int ID { get; set; }
        public string foodType { get; set; }
    }
}
