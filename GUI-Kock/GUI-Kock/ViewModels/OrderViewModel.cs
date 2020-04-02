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

namespace GUI_Kock.ViewModels
{
    public class OrderViewModel : ReactiveObject, IRoutableViewModel
    {

        public ChefRepository repo = new ChefRepository();

        public Order _selectedOrders;
        public ObservableCollection<Order> OngoinOrders { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToPreparingView { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        public LoginViewModel _login;

        public Employee _admin;
        public ObservableCollection<Pizza> Pizzas { get; }

        public Order SelectedOrders
        {
            get
            {
                return _selectedOrders;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedOrders, value);
            }
        }


        #region Routing
        public string UrlPathSegment => "Order";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
        #endregion



        public OrderViewModel(RoutingState state, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Router = state;
            OngoinOrders = new ObservableCollection<Order>();
            _admin = new Employee();
            _login = new LoginViewModel(Router);

            //Registrerar din nästa view. denna behövs för att kunna koppla den mot ett command
            Locator.CurrentMutable.Register(() => new PreparingOrderView(), typeof(IViewFor<PreparingOrderViewModel>));
            GoToPreparingView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PreparingOrderViewModel(Router)));

            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));
        }

        public void PopulateOrders()
        {
            IEnumerable<Order> orders = repo.ShowOrderByStatus(Order.eStatus.Tillagning);
            OngoinOrders.AddRange(orders);
        }

    }
}
