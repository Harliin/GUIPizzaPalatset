using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace GUI_Kock.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; private set; }

        #region Routing
        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
        #endregion



        public LoginViewModel(RoutingState state, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Router = state;
            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel(Router)));
        
        }

    }
}
