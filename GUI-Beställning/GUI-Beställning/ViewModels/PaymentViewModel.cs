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
        public ObservableCollection<string> CurrentOrderName { get; set; }
        public ObservableCollection<int> CurrentOrderPrice { get; set; }
        public ObservableCollection<int> CurrentFoodID { get; set; }
        public ObservableCollection<string> FoodType { get; set; }

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
            CurrentOrderName = new ObservableCollection<string>();
            CurrentOrderPrice = new ObservableCollection<int>();
            CurrentFoodID = new ObservableCollection<int>();
            FoodType = new ObservableCollection<string>();


            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { CurrentOrderName.Add(pizza.Name); CurrentOrderPrice.Add(pizza.Price); CurrentFoodID.Add(pizza.ID); FoodType.Add("pizza"); });
            CurrentOrder.pasta.ForEach(pasta => { CurrentOrderName.Add(pasta.Name); CurrentOrderPrice.Add(pasta.Price); CurrentFoodID.Add(pasta.ID); FoodType.Add("pasta"); });
            CurrentOrder.sallad.ForEach(sallad => { CurrentOrderName.Add(sallad.Name); CurrentOrderPrice.Add(sallad.Price); CurrentFoodID.Add(sallad.ID); FoodType.Add("sallad"); });
            CurrentOrder.drink.ForEach(drink => { CurrentOrderName.Add(drink.Name); CurrentOrderPrice.Add(drink.Price); CurrentFoodID.Add(drink.ID); FoodType.Add("drink"); });
            CurrentOrder.extra.ForEach(extra => { CurrentOrderName.Add(extra.Name); CurrentOrderPrice.Add(extra.Price); CurrentFoodID.Add(extra.ID); FoodType.Add("extra"); });

            
        }
        public void RemoveFoodFromOrder(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var foodType = (string)values[1];
        }
    }
}
