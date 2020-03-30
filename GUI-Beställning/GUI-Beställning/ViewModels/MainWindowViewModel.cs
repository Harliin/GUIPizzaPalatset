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
    public class MainWindowViewModel : ReactiveObject, IScreen, INotifyPropertyChanged
    {
        //public event  PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public OrderRepository repo = new OrderRepository();
        public RoutingState Router { get; }
        public Order CurrentOrder { get; set; }
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


            PizzaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PizzaMenuViewModel()));

            PastaMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PastaMenuViewModel()));

            SalladMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SalladMenuViewModel()));

            DrinkMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new DrinkMenuViewModel()));

            ExtraMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ExtraMenuViewModel()));

            PaymentMenu = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PaymentViewModel()));

            Router.Navigate.Execute(new WelcomeViewModel());

            #endregion

            ShowOrder();
        }

        public void ShowOrder()
        {
            TotalPrice = 0;
            Order = new ObservableCollection<object>();

            var ordersIE = repo.ShowOrderByID(OrderID);
            var temp = ordersIE.ToList();

            CurrentOrder = temp[0];
            CurrentOrder.pizza.ForEach(pizza => { Order.Add(pizza); TotalPrice += pizza.Price; });
            CurrentOrder.pasta.ForEach(pasta => { Order.Add(pasta); TotalPrice += pasta.Price; });
            CurrentOrder.sallad.ForEach(sallad => { Order.Add(sallad); TotalPrice += sallad.Price; });
            CurrentOrder.drink.ForEach(drink => { Order.Add(drink); TotalPrice += drink.Price; });
            CurrentOrder.extra.ForEach(extra => { Order.Add(extra); TotalPrice += extra.Price; });

            //PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurOrder)));
        }
    }
}
