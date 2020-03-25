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
        public Order CurrentOrders { get; set; }
        public OrderRepository repo = new OrderRepository();
        public List<string> CurrentOrderName { get; set; }
        public List<int> CurrentOrderPrice { get; set; }
        //public List<List<int>> CurrentFoodID { get; set; }
        public int[,] CurrentFoodID { get; set; }

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
            CurrentFoodID = new int[new List<int>, new List<int>] ;

            #region Temp Lists
            List<int> pizzaList = new List<int>();
            List<int> pastaList = new List<int>();
            List<int> salladList = new List<int>();
            List<int> drinkList = new List<int>();
            List<int> extraList = new List<int>();

            #endregion

            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            CurrentOrders = temp[0];
            CurrentOrders.pizza.ForEach(pizza => { CurrentOrderName.Add(pizza.Name); CurrentOrderPrice.Add(pizza.Price); pizzaList.Add(pizza.ID); });
            CurrentOrders.pasta.ForEach(pasta => { CurrentOrderName.Add(pasta.Name); CurrentOrderPrice.Add(pasta.Price); pastaList.Add(pasta.ID); });
            CurrentOrders.sallad.ForEach(sallad => { CurrentOrderName.Add(sallad.Name); CurrentOrderPrice.Add(sallad.Price); salladList.Add(sallad.ID); });
            CurrentOrders.drink.ForEach(drink => { CurrentOrderName.Add(drink.Name); CurrentOrderPrice.Add(drink.Price); drinkList.Add(drink.ID); });
            CurrentOrders.extra.ForEach(extra => { CurrentOrderName.Add(extra.Name); CurrentOrderPrice.Add(extra.Price); extraList.Add(extra.ID); });

            #region Adds lists of food 
            CurrentFoodID.Add(pizzaList);
            CurrentFoodID.Add(pastaList);
            CurrentFoodID.Add(salladList);
            CurrentFoodID.Add(drinkList);
            CurrentFoodID.Add(extraList);
            #endregion
        }
        public void RemoveFoodFromOrder(object id)
        {
            var kind = id;
        }
    }
}
