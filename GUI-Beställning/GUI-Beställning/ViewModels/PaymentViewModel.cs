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
    public class PaymentViewModel : ReactiveObject, IRoutableViewModel, INotifyPropertyChanged
    {
        #region For Reactive UI
        public string UrlPathSegment => "PaymentMenu";

        public IScreen HostScreen { get; }
        #endregion
        public Order CurrentOrder { get; set; }
        public OrderRepository repo = new OrderRepository();
        //public IObservable<IReactivePropertyChangedEventArgs<T>> Changed { get; }
        private ObservableCollection<object> _Foods;
        public ObservableCollection<object> Foods 
        {
            get { return _Foods; }
            set 
            {

                var ordersIE = repo.ShowOrderByID(this.OrderID);
                var temp = ordersIE.ToList();
                CurrentOrder = temp[0];

                CurrentOrder.pizza.ForEach(pizza => { Foods.Add(pizza); });
                CurrentOrder.pasta.ForEach(pasta => { Foods.Add(pasta); });
                CurrentOrder.sallad.ForEach(sallad => { Foods.Add(sallad); });
                CurrentOrder.drink.ForEach(drink => { Foods.Add(drink); });
                CurrentOrder.extra.ForEach(extra => { Foods.Add(extra); });

                this.RaiseAndSetIfChanged(ref _Foods, Foods);
                //INotifyPropertyChanged()
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
            Foods = new ObservableCollection<object>();
            //Changed = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>
            //(
            //t => PropertyChanged += t, // add handler
            //t => PropertyChanged -= t  // remove handler
            //// conversion from EventPattern to ReactivePropertyChangedEventArgs
            //).Select(ev => new ReactivePropertyChangedEventArgs<T>(ev.Sender as T, ev.EventArgs.PropertyName));
        }

        //public void ShowOrder()
        //{
        //    Foods = new ObservableCollection<object>();

        //    var ordersIE = repo.ShowOrderByID(this.OrderID);
        //    var temp = ordersIE.ToList();
        //    CurrentOrder = temp[0];

        //    CurrentOrder.pizza.ForEach(pizza => { Foods.Add(pizza); });
        //    CurrentOrder.pasta.ForEach(pasta => { Foods.Add(pasta); });
        //    CurrentOrder.sallad.ForEach(sallad => { Foods.Add(sallad); });
        //    CurrentOrder.drink.ForEach(drink => { Foods.Add(drink); });
        //    CurrentOrder.extra.ForEach(extra => { Foods.Add(extra); });


        //}

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
    }

}
