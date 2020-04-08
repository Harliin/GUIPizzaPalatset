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

        #region Commands
        public RoutingState Router { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToView { get; }

        #endregion

        #region Properties
        public Window thisWindow { get; set; }
        #endregion

        #region Default Constructor
        public MainWindowViewModel(Window thisWindow)
        {
            // Initialize the Router.
            Router = new RoutingState();
            this.thisWindow = thisWindow;
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            Router.Navigate.Execute(new LoginViewModel(Router));
        }
        #endregion
    }

}
