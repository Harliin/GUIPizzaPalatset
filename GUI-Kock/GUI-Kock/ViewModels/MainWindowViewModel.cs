using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using System.Reactive;
using Splat;
using System.Windows;
using GUI_Kock.Views;
using System.Threading.Tasks;

namespace GUI_Kock.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        //Command to navigate to another view
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; }

        public Window thisWindow { get; set; }

        public MainWindowViewModel(Window thisWindow)
        {
            // Initialize the Router.
            Router = new RoutingState();

            this.thisWindow = thisWindow;


            // Instead of registering views manually, you 
            // can use custom IViewLocator implementation,
            // see "View Location" section for details.
            //
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));

            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel(Router)));
        }
    }
}
