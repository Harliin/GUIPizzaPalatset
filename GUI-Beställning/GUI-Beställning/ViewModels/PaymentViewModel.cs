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
        public List<string> CurrentOrderName { get; set; }
        public List<int> CurrentOrderPrice { get; set; }
        public List<int> CurrentFoodID { get; set; }
        public List<Order.eFoodType> foodType { get; set; }

        public RelayCommand RemoveCommand { get; set; }
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
            CurrentFoodID = new List<int>();
            foodType = new List<Order.eFoodType>();


            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { CurrentOrderName.Add(pizza.Name); CurrentOrderPrice.Add(pizza.Price); CurrentFoodID.Add(pizza.ID); foodType.Add(Order.eFoodType.pizza); });
            CurrentOrder.pasta.ForEach(pasta => { CurrentOrderName.Add(pasta.Name); CurrentOrderPrice.Add(pasta.Price); CurrentFoodID.Add(pasta.ID); foodType.Add(Order.eFoodType.pasta); });
            CurrentOrder.sallad.ForEach(sallad => { CurrentOrderName.Add(sallad.Name); CurrentOrderPrice.Add(sallad.Price); CurrentFoodID.Add(sallad.ID); foodType.Add(Order.eFoodType.sallad); });
            CurrentOrder.drink.ForEach(drink => { CurrentOrderName.Add(drink.Name); CurrentOrderPrice.Add(drink.Price); CurrentFoodID.Add(drink.ID); foodType.Add(Order.eFoodType.drink); });
            CurrentOrder.extra.ForEach(extra => { CurrentOrderName.Add(extra.Name); CurrentOrderPrice.Add(extra.Price); CurrentFoodID.Add(extra.ID); foodType.Add(Order.eFoodType.extra); });

            
        }
        public void RemoveFoodFromOrder(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var foodType = (Order.eFoodType)values[1];
        }
    }
}
