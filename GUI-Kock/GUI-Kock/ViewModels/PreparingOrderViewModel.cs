using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using GUI_Kock.Views;
using System.Reactive;
using System.Windows;
using Food;

namespace GUI_Kock.ViewModels
{
    public class PreparingOrderViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

            
        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _id, value);
            }
        }



        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        #region Routing
        public string UrlPathSegment => "Preparing";
        public IScreen HostScreen { get; }
        public RoutingState Router => LoginViewModel.Router;
        #endregion
        public PreparingOrderViewModel(string name, Order order, IScreen screen = null)
        {
            Name = name;
            //ID = id;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));

        }

    }
}
