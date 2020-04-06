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
using System.Linq;

namespace GUI_Kock.ViewModels
{
    public class OrderViewModel : ReactiveObject, IRoutableViewModel
    {
        public List<string> EmployeeNames { get; private set; }

        public ChefRepository repo = new ChefRepository();

        public ObservableCollection<Order> OngoinOrders { get; private set; }
        
        public ObservableCollection<Pizza> Pizzas { get; }

        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                { 

                this.RaiseAndSetIfChanged(ref _id, value);
                }

            }
        }

        public static string Name { get; set; }

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


        public OrderViewModel(string name = null, IScreen screen = null)
        {
            if (Name == null)
            {
                Name = name;
            }

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


        public void NavigateToPreparingView(object parameter)
        {
            Order temporder = (Order)parameter;
            Router.Navigate.Execute(new PreparingOrderViewModel(Name, temporder));
        }

        public void PopulateOrders()
        {
            IEnumerable<Order> orders = repo.ShowOrderByStatus(Order.eStatus.Tillagning);
            OngoinOrders.AddRange(orders);
        }


    }
}
