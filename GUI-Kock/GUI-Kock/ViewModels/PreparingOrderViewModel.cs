using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using GUI_Kock.Views;

namespace GUI_Kock.ViewModels
{
    public class PreparingOrderViewModel : ReactiveObject, IRoutableViewModel
    {
        // public ReactiveCommand<Unit, IRoutableViewModel> GoToMainView { get; }


        #region Routing
        public string UrlPathSegment => "Preparing";
        public IScreen HostScreen { get; }
        public  RoutingState Router => OrderViewModel.Router;
        #endregion
        public PreparingOrderViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
           
            // GoToMainView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new MainViewModel(Router)));

        }

    }
}
