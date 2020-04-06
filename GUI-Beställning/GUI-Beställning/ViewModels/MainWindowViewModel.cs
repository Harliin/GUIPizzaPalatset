using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using GUI_Beställning.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        #region Properties
        public OrderRepository repo = new OrderRepository();
        public RoutingState Router { get; }
        public Order CurrentOrder { get; set; }
        public PaymentViewModel PaymentVM { get; set; }
        public PizzaMenuViewModel PizzaVM { get; set; }
        public ObservableCollection<object> Order { get; set; }


        public int TotalPrice { get; set; }
        public static int OrderID { get; set; }
        #endregion

        #region Commands
        public ReactiveCommand<Unit, IRoutableViewModel> PizzaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> PastaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> SalladMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> DrinkMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ExtraMenu { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> PaymentMenu { get; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            //Only for starting of with a OrderID
            if (OrderID == 0)
            {
                GetNewOrderID();
            }
            
            Router = new RoutingState();
            #region Navigation Reactive UI

            Locator.CurrentMutable.Register(() => new PizzaMenuView(), typeof(IViewFor<PizzaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PastaMenuView(), typeof(IViewFor<PastaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new SalladMenuView(), typeof(IViewFor<SalladMenuViewModel>));

            Locator.CurrentMutable.Register(() => new DrinkMenuView(), typeof(IViewFor<DrinkMenuViewModel>));

            Locator.CurrentMutable.Register(() => new ExtraMenuView(), typeof(IViewFor<ExtraMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PaymentView(), typeof(IViewFor<PaymentViewModel>));

            Locator.CurrentMutable.Register(() => new WelcomeView(), typeof(IViewFor<WelcomeViewModel>));

            Locator.CurrentMutable.Register(() => new ReceiptView(), typeof(IViewFor<ReceiptViewModel>));

            
            PizzaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PizzaMenuViewModel(this)));

            PastaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PastaMenuViewModel(this)));

            SalladMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SalladMenuViewModel(this)));

            DrinkMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new DrinkMenuViewModel(this)));

            ExtraMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ExtraMenuViewModel(this)));

            PaymentMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PaymentViewModel(this)));

            Router.Navigate.Execute(new WelcomeViewModel());

            #endregion
            //var order = ShowOrder();
            this.Order = new ObservableCollection<object>();
            Task.Run(() => ShowOrder());
            
        }

        #region Methods

        /// <summary>
        /// Adds all the foods in a order to a observable collection
        /// </summary>
        public async void ShowOrder()
        {
            //await Task.Run(() =>
            //{
               
            //});
            TotalPrice = 0;
            List<object> OrderList = new List<object>();
            var ordersIE = await repo.ShowOrderByID(OrderID);
            var temp = ordersIE.ToList();

            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { OrderList.Add(pizza); TotalPrice += pizza.Price; });
            CurrentOrder.pasta.ForEach(pasta => { OrderList.Add(pasta); TotalPrice += pasta.Price; });
            CurrentOrder.sallad.ForEach(sallad => { OrderList.Add(sallad); TotalPrice += sallad.Price; });
            CurrentOrder.drink.ForEach(drink => { OrderList.Add(drink); TotalPrice += drink.Price; });
            CurrentOrder.extra.ForEach(extra => { OrderList.Add(extra); TotalPrice += extra.Price; });
            this.RaisePropertyChanged(nameof(TotalPrice));
            Order.Clear();
            Order.AddRange(OrderList);

            //return OrderList;

        }


        #region Command Methods
        /// <summary>
        /// Method gets called uppon to update GUI
        /// </summary>
        public async void OrderChanged()
        {
            Task.Run(() => ShowOrder());
            //this.Order.Clear();
            //var list = ShowOrder();
            //this.Order.AddRange(list);
        }


        /// <summary>
        /// Command Method to Navigate from PaymentView to RecieptView
        /// </summary>
        /// <param name="parameter"></param>
        public async Task PaymentCommandMethod(object parameter)
        {
            await Task.Run(() =>
            {
                if (Order.Count != 0)
                {
                    Router.Navigate.Execute(new ReceiptViewModel(this));
                }
            });
            
        }


        /// <summary>
        /// method to reset everything for the next customer.
        /// </summary>
        /// <param name="parameter"></param>
        public void CheckoutCommandMethod(object parameter)
        {
            //Ändrar ordern sstatus och rensar sedan listan order
            repo.UpdateOrderStatus(OrderID);
            Order.Clear();
            TotalPrice = 0;
            this.RaisePropertyChanged(nameof(TotalPrice));

            //Hämtar det nya OrderIDt
            GetNewOrderID();
            
            //Navigerar tillbaka till start.
            MessageBox.Show("*Skriver ut kvitto*");
            Router.Navigate.Execute(new WelcomeViewModel());
        }

        private async void GetNewOrderID()
        {
            //ändra detta sen när man ska skapa nya ordrar
            //var newOrder = (repo.CreateNewOrder()).ToList();
            //OrderID = newOrder[0].ID; 
            OrderID = 160;
        }
        #endregion

        #endregion
    }
}
