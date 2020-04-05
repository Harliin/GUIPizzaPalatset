using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using GUI_Kock.Views;
using System.Reactive;

namespace GUI_Kock.ViewModels
{
    public class PreparingOrderViewModel : ReactiveObject, IRoutableViewModel
    {

        public ReactiveCommand<Unit, IRoutableViewModel> GoToLoginView { get; private set; }

        #region Routing
        public string UrlPathSegment => "Preparing";
        public IScreen HostScreen { get; }
        public RoutingState Router => LoginViewModel.Router;
        #endregion
        public PreparingOrderViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            GoToLoginView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new LoginViewModel(Router)));

        }

    }
}
