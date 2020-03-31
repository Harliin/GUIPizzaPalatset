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
using System.Text;
using System.Windows.Input;

namespace GUI_Beställning.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        //public event EventHandler<string> OrderChanged;
        //public event CollectionChangeEventHandler OrderChanged;
        public OrderRepository repo = new OrderRepository();
        public RoutingState Router { get; }
        public Order CurrentOrder { get; set; }
        public PaymentViewModel PaymentVM { get; set; }
        public PizzaMenuViewModel PizzaVM { get; set; }
        public ObservableCollection<object> Order { get; set; }


        public int TotalPrice { get; set; }
        public static int OrderID { get; set; }

        #region Commands
        public ReactiveCommand<Unit, IRoutableViewModel> PizzaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> PastaMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> SalladMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> DrinkMenu { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ExtraMenu { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> PaymentMenu { get; }

        #endregion

        public MainWindowViewModel()
        {
            
            OrderID = 125;

            Router = new RoutingState();
            #region Navigation Reactive UI

            Locator.CurrentMutable.Register(() => new PizzaMenuView(), typeof(IViewFor<PizzaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PastaMenuView(), typeof(IViewFor<PastaMenuViewModel>));

            Locator.CurrentMutable.Register(() => new SalladMenuView(), typeof(IViewFor<SalladMenuViewModel>));

            Locator.CurrentMutable.Register(() => new DrinkMenuView(), typeof(IViewFor<DrinkMenuViewModel>));

            Locator.CurrentMutable.Register(() => new ExtraMenuView(), typeof(IViewFor<ExtraMenuViewModel>));

            Locator.CurrentMutable.Register(() => new PaymentView(), typeof(IViewFor<PaymentViewModel>));

            Locator.CurrentMutable.Register(() => new WelcomeView(), typeof(IViewFor<WelcomeViewModel>));


            PizzaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PizzaMenuViewModel(this)));

            PastaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PastaMenuViewModel()));

            SalladMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SalladMenuViewModel()));

            DrinkMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new DrinkMenuViewModel()));

            ExtraMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ExtraMenuViewModel()));

            PaymentMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PaymentViewModel(this)));

            Router.Navigate.Execute(new WelcomeViewModel());

            #endregion

            this.Order = new ObservableCollection<object>(ShowOrder());
            
        }


        /// <summary>
        /// Adds all the foods in a order to a observable collection
        /// </summary>
        public List<object> ShowOrder()
        {
            TotalPrice = 0;
            //Order = new ObservableCollection<object>();
            List<object> OrderList = new List<object>();
            var ordersIE = repo.ShowOrderByID(OrderID);
            var temp = ordersIE.ToList();

            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { OrderList.Add(pizza); TotalPrice += pizza.Price; });
            CurrentOrder.pasta.ForEach(pasta => { OrderList.Add(pasta); TotalPrice += pasta.Price; });
            CurrentOrder.sallad.ForEach(sallad => { OrderList.Add(sallad); TotalPrice += sallad.Price; });
            CurrentOrder.drink.ForEach(drink => { OrderList.Add(drink); TotalPrice += drink.Price; });
            CurrentOrder.extra.ForEach(extra => { OrderList.Add(extra); TotalPrice += extra.Price; });

            return OrderList;

        }

        public void MyPropertyOrderChanged()
        {
            this.Order.Clear();
            var list = ShowOrder();
            this.Order.AddRange(list);
            //this.RaisePropertyChanged(nameof(Order));
        }
        
        
    }
}
