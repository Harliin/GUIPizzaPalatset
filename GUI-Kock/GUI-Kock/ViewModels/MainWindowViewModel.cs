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
        public ReactiveCommand<Unit, IRoutableViewModel> GoToView { get; }

        public Window thisWindow { get; set; }

        public MainWindowViewModel(Window thisWindow)
        {
            // Initialize the Router.
            Router = new RoutingState();

            this.thisWindow = thisWindow;

            //Jesse Comments Detta Behövs inte då vi under App starten registerar alla vyer

            // Instead of registering views manually, you 
            // can use custom IViewLocator implementation,
            // see "View Location" section for details.
            //
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));


            //Jesse detta är om du vill byta frame genom en knapp
            //GoToView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new StartViewModel()));

            Router.Navigate.Execute(new LoginViewModel(Router));
        }
    }
    
}
