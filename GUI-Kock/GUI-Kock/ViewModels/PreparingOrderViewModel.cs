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

namespace GUI_Kock.ViewModels
{
    public class PreparingOrderViewModel : ReactiveObject, IRoutableViewModel
    {
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


        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        #region Routing
        public string UrlPathSegment => "Preparing";
        public IScreen HostScreen { get; }
        public RoutingState Router => LoginViewModel.Router;
        #endregion
        public PreparingOrderViewModel(string name, Order order, IScreen screen = null)
        {
            EmployeeName = name;
            CurrentOrder = order;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));

        }

    }
}
