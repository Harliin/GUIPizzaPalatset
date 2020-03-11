
using GUI_Beställning.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindowView()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();

            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.PizzaMenu, x => x.GoPizzaMenu)//PizzaButton
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.PastaMenu, x => x.GoPastaMenu)//PastaButton
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.SalladMenu, x => x.GoSalladMenu)//SalladButton
                   .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.DrinkMenu, x => x.GoDrinkMenu)//DrinkButton
                   .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.ExtraMenu, x => x.GoExtraMenu)//ExtraButton
                   .DisposeWith(disposables);
            });

        }
    }
}
