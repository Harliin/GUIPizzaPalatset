using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using GUI_Kock.Views;
using DB_Kock;

namespace GUI_Kock.ViewModels
{
    public class OrderViewModel : ReactiveObject, IRoutableViewModel
    {

        public ChefRepository repo = new ChefRepository();
        public ReactiveCommand<Unit, IRoutableViewModel> GoToPreparingView { get; private set; }
       

        #region Routing
        public string UrlPathSegment => "Order";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
        #endregion



        public OrderViewModel(RoutingState state, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Router = state;
            GoToPreparingView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PreparingOrderViewModel(Router)));

        }

    }
}
