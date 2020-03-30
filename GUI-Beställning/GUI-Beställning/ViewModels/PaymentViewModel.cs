using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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
        private ObservableCollection<object> _Foods;
        public ObservableCollection<object> Foods 
        {
            get { return _Foods; }
            set 
            {
                this.RaiseAndSetIfChanged(ref _Foods, ShowOrder());
                this.RaisePropertyChanged(nameof(Foods));
            }
        }
        


        public RelayCommand RemoveCommand { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public int OrderID { get; set; }
        public PaymentViewModel(IScreen screen = null)
        {
            RemoveCommand = new RelayCommand(RemoveFoodFromOrder);
            OrderID = MainWindowViewModel.OrderID;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            //_Foods = new ObservableCollection<object>();
            //Foods = new ObservableCollection<object>();
            this.Foods = new ObservableCollection<object>();
        }

        /// <summary>
        /// Adds all the foods in a order to a observable Collection
        /// </summary>
        public ObservableCollection<object> ShowOrder()
        {

            var ordersIE = repo.ShowOrderByID(this.OrderID);
            var temp = ordersIE.ToList();
            List<object> myList = new List<object>();
            CurrentOrder = temp[0];

            CurrentOrder.pizza.ForEach(pizza => { myList.Add(pizza); });
            CurrentOrder.pasta.ForEach(pasta => { myList.Add(pasta); });
            CurrentOrder.sallad.ForEach(sallad => { myList.Add(sallad); });
            CurrentOrder.drink.ForEach(drink => { myList.Add(drink); });
            CurrentOrder.extra.ForEach(extra => { myList.Add(extra); });

            //if (CurrentOrder.pizza != null)
            //{
            //    CurrentOrder.pizza.ForEach(pizza => { myList.Add(pizza); });
            //}
            //else if (CurrentOrder.pasta != null)
            //{
            //    CurrentOrder.pasta.ForEach(pasta => { myList.Add(pasta); });
            //}
            //else if (CurrentOrder.sallad != null)
            //{
            //    CurrentOrder.sallad.ForEach(sallad => { myList.Add(sallad); });
            //}
            //else if (CurrentOrder.drink != null)
            //{
            //    CurrentOrder.drink.ForEach(drink => { myList.Add(drink); });
            //}
            //else if (CurrentOrder.extra != null)
            //{
            //    CurrentOrder.extra.ForEach(extra => { myList.Add(extra); });
            //}
            return new ObservableCollection<object>(myList);
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
            Foods = new ObservableCollection<object>();
            this.RaisePropertyChanged(nameof(Foods));
        }
    }

}
