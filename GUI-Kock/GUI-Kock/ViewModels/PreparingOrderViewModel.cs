using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using GUI_Kock.Views;
using System.Reactive;
using System.Windows;
using Food;
using System.Collections.ObjectModel;
using DynamicData;
using System.Linq;
using DB_Kock;
using GUI_Kock.ViewModels.Commands;

namespace GUI_Kock.ViewModels
{
    public class PreparingOrderViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Properties
        private string _employeename;

        public string EmployeeName
        {
            get
            {
                return _employeename;
            }
            set
            {
                _employeename = value;
            }
        }

        public static ChefRepository repos => LoginViewModel.repo;

        public Order CurrentOrder { get; private set; }

        public ObservableCollection<object> orderItems { get; }

        #endregion

        #region Commands
        public RelayCommand UpdateOrder { get; set; }

        public RelayCommand Timer { get; set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; private set; }

        #endregion

        #region Routing
        public string UrlPathSegment => "Preparing";
        public IScreen HostScreen { get; }
        public RoutingState Router => LoginViewModel.Router;
        #endregion

        #region Default Constructor
        public PreparingOrderViewModel(Order order, string name = null, IScreen screen = null)
        {

            CurrentOrder = order;

            if (EmployeeName == null)
            {
                EmployeeName = name;
            }

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));
            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel()));
            UpdateOrder = new RelayCommand(UpdateOrderStatus);
            Timer = new RelayCommand(TimerOn);
            orderItems = new ObservableCollection<object>();
            ShowOrderItem();
        }

        #endregion

        #region Command metoder
        private void UpdateOrderStatus(object parameter)
        {
            //access only if there's no orderItems
            repos.UpdateOrderStatus(CurrentOrder.ID);
            Router.Navigate.Execute(new OrderViewModel());
        }

        private void TimerOn(object parameter)
        {
            System.Threading.Thread.Sleep(5000);
            Console.Beep(500, 2000);
        }

        public void ShowOrderItem()
        {
            CurrentOrder.pizza.ForEach(pizza => { orderItems.Add(pizza); });
            CurrentOrder.pasta.ForEach(pasta => { orderItems.Add(pasta); });
            CurrentOrder.sallad.ForEach(sallad => { orderItems.Add(sallad); });
            CurrentOrder.drink.ForEach(drink => { orderItems.Add(drink); });
            CurrentOrder.extra.ForEach(extra => { orderItems.Add(extra); });

        }

        #endregion
    }
}
