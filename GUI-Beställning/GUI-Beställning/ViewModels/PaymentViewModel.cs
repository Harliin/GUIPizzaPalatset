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
        public Order CurrentOrders { get; set; }
        public OrderRepository repo = new OrderRepository();
        public List<string> CurrentOrderName { get; set; }
        public List<int> CurrentOrderPrice { get; set; }

        public RelayCommand RemoveCommand { get; set; }
        //public ReactiveCommand<Unit, >
        public List<int> CurrentOrderID { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public int OrderID { get; set; }
        public PaymentViewModel(IScreen screen = null)
        {
            RemoveCommand = new RelayCommand(RemoveFoodFromOrder);
            OrderID = 124;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            ShowOrder();
            
        }

        public void ShowOrder()
        {
            CurrentOrderName = new List<string>();
            CurrentOrderPrice = new List<int>();
            CurrentOrderID = new List<int>();
            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            CurrentOrders = temp[0];
            CurrentOrders.pizza.ForEach(pizza => { CurrentOrderName.Add(pizza.Name); CurrentOrderPrice.Add(pizza.Price); CurrentOrderID.Add(pizza.ID); });
            CurrentOrders.pasta.ForEach(pasta => { CurrentOrderName.Add(pasta.Name); CurrentOrderPrice.Add(pasta.Price); CurrentOrderID.Add(pasta.ID); });
            CurrentOrders.sallad.ForEach(sallad => { CurrentOrderName.Add(sallad.Name); CurrentOrderPrice.Add(sallad.Price); CurrentOrderID.Add(sallad.ID); });
            CurrentOrders.drink.ForEach(drink => { CurrentOrderName.Add(drink.Name); CurrentOrderPrice.Add(drink.Price); CurrentOrderID.Add(drink.ID); });
            CurrentOrders.extra.ForEach(extra => { CurrentOrderName.Add(extra.Name); CurrentOrderPrice.Add(extra.Price); CurrentOrderID.Add(extra.ID); });
        }
        public void RemoveFoodFromOrder(object id)
        {
            var kind = id;
        }
    }
}
