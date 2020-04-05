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

        public ObservableCollection<Order> OngoinOrders { get; private set; }
        
        public ObservableCollection<Pizza> Pizzas { get; }

        public LoginViewModel loginViewModel;

        #region Commands
        public RelayCommand GoToPreparingViewCommand { get; set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToPreparingView { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        #endregion

        #region Routing
        public string UrlPathSegment => "Order";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router => LoginViewModel.Router;
        #endregion


        public OrderViewModel(IScreen screen = null)
        {
            loginViewModel = new LoginViewModel();
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
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
