using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using GUI_Kock.Views;
using DB_Kock;
using Food;
using System.Collections.ObjectModel;
using DynamicData;
using GUI_Kock.ViewModels.Commands;
using System.Windows;

namespace GUI_Kock.ViewModels
{
    public class OrderViewModel : ReactiveObject, IRoutableViewModel
    {

        public ChefRepository repo = new ChefRepository();

        public Order _selectedOrders;
        public ObservableCollection<Order> OngoinOrders { get; private set; }
        
        public ObservableCollection<Pizza> Pizzas { get; }
        #region Commands
        public RelayCommand GoToPreparingViewCommand { get; set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToPreparingView { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        #endregion


        //public Order SelectedOrders
        //{
        //    get
        //    {
        //        return _selectedOrders;
        //    }
        //    set
        //    {
        //        this.RaiseAndSetIfChanged(ref _selectedOrders, value);
        //        if (value != null)
        //        {
        //            Router.Navigate.Execute(new PreparingOrderViewModel(Router));
        //        }
        //    }
        //    }


        #region Routing
        public string UrlPathSegment => "Order";
        public IScreen HostScreen { get; private set; }
        public static RoutingState Router { get; private set; }
        #endregion


        public OrderViewModel(RoutingState state = null, IScreen screen = null)
        {
            // SelectedOrders = null;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            if (Router == null)
            {
                Router = state;
            }
            OngoinOrders = new ObservableCollection<Order>();
            GoToPreparingViewCommand = new RelayCommand(NavigateToPreparingView);
            Locator.CurrentMutable.Register(() => new PreparingOrderView(), typeof(IViewFor<PreparingOrderViewModel>));
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));
        }

        // <summary>
        // Gets the loginCommand for the ViewModel  
        // </summary>
        

        public void NavigateToPreparingView()
        {
            Router.Navigate.Execute(new PreparingOrderViewModel());
        }

        public void PopulateOrders()
        {
            IEnumerable<Order> orders = repo.ShowOrderByStatus(Order.eStatus.Tillagning);
            OngoinOrders.AddRange(orders);
        }

    }
}
